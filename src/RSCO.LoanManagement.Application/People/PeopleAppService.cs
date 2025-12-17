using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using RSCO.LoanManagement.People.Exporting;
using RSCO.LoanManagement.People.Dtos;
using RSCO.LoanManagement.Dto;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using RSCO.LoanManagement.Storage;
using RSCO.LoanManagement.LoanContractPersons;
using RSCO.LoanManagement.LoanContracts.Dtos;

namespace RSCO.LoanManagement.People
{
    [AbpAuthorize(AppPermissions.Pages_People)]
    public class PeopleAppService : LoanManagementAppServiceBase, IPeopleAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IPeopleExcelExporter _peopleExcelExporter;
        private readonly IRepository<LoanContractPerson, Guid> _loanContractPersonRepository;

        public PeopleAppService(IRepository<Person, Guid> personRepository, IPeopleExcelExporter peopleExcelExporter, IRepository<LoanContractPerson, Guid> loanContractPersonRepository)
        {
            _personRepository = personRepository;
            _peopleExcelExporter = peopleExcelExporter;
            _loanContractPersonRepository = loanContractPersonRepository;

        }

        public virtual async Task<PagedResultDto<GetPersonForViewDto>> GetAll(GetAllPeopleInput input)
        {

            var filteredPeople = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName.Contains(input.FirstNameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName.Contains(input.LastNameFilter));

            var pagedAndFilteredPeople = filteredPeople
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var people = from o in pagedAndFilteredPeople
                         select new
                         {

                             o.FirstName,
                             o.LastName,
                             Id = o.Id
                         };

            var totalCount = await filteredPeople.CountAsync();

            var dbList = await people.ToListAsync();
            var results = new List<GetPersonForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetPersonForViewDto()
                {
                    Person = new PersonDto
                    {

                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPersonForViewDto>(
                totalCount,
                results
            );

        }

        public virtual async Task<GetPersonForViewDto> GetPersonForView(Guid id)
        {
            var person = await _personRepository.GetAsync(id);

            var output = new GetPersonForViewDto { Person = ObjectMapper.Map<PersonDto>(person) };

            var relations = await _loanContractPersonRepository.GetAll()
                .Include(x => x.LoanContract)
                .Where(x => x.PersonId == id)
                .ToListAsync();

            output.BorrowerLoanContracts = relations
                .Where(x => x.Role == LoanContractPersonRole.Borrower && x.LoanContract != null)
                .Select(x => new LoanContractDto
                {
                    Id = x.LoanContractId,
                    ContractDate = x.LoanContract.ContractDate,
                    Amount = x.LoanContract.Amount,
                    Summery = x.LoanContract.Summery
                })
                .OrderByDescending(lc => lc.ContractDate)
                .ToList();

            output.GuarantorLoanContracts = relations
                .Where(x => x.Role == LoanContractPersonRole.Guarantor && x.LoanContract != null)
                .Select(x => new LoanContractDto
                {
                    Id = x.LoanContractId,
                    ContractDate = x.LoanContract.ContractDate,
                    Amount = x.LoanContract.Amount,
                    Summery = x.LoanContract.Summery
                })
                .OrderByDescending(lc => lc.ContractDate)
                .ToList();

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_People_Edit)]
        public virtual async Task<GetPersonForEditOutput> GetPersonForEdit(EntityDto<Guid> input)
        {
            var person = await _personRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPersonForEditOutput { Person = ObjectMapper.Map<CreateOrEditPersonDto>(person) };

            return output;
        }

        public virtual async Task CreateOrEdit(CreateOrEditPersonDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_People_Create)]
        protected virtual async Task Create(CreateOrEditPersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);

            await _personRepository.InsertAsync(person);

        }

        [AbpAuthorize(AppPermissions.Pages_People_Edit)]
        protected virtual async Task Update(CreateOrEditPersonDto input)
        {
            var person = await _personRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, person);

        }

        [AbpAuthorize(AppPermissions.Pages_People_Delete)]
        public virtual async Task Delete(EntityDto<Guid> input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public virtual async Task<FileDto> GetPeopleToExcel(GetAllPeopleForExcelInput input)
        {

            var filteredPeople = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName.Contains(input.FirstNameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName.Contains(input.LastNameFilter));

            var query = (from o in filteredPeople
                         select new GetPersonForViewDto()
                         {
                             Person = new PersonDto
                             {
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 Id = o.Id
                             }
                         });

            var personListDtos = await query.ToListAsync();

            return _peopleExcelExporter.ExportToFile(personListDtos);
        }

        public async Task<List<PersonDto>> GetAllPeopleForTableDropdown()
        {
            return await _personRepository.GetAll()
                .Select(person => new PersonDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                })
                .ToListAsync();
        }

    }
}
