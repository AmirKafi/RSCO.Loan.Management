using RSCO.LoanManagement.People;
using RSCO.LoanManagement.LoanContracts;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using RSCO.LoanManagement.LoanContractPersons.Exporting;
using RSCO.LoanManagement.LoanContractPersons.Dtos;
using RSCO.LoanManagement.Dto;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using RSCO.LoanManagement.Storage;

namespace RSCO.LoanManagement.LoanContractPersons
{
    [AbpAuthorize(AppPermissions.Pages_LoanContractPersons)]
    public class LoanContractPersonsAppService : LoanManagementAppServiceBase, ILoanContractPersonsAppService
    {
        private readonly IRepository<LoanContractPerson, Guid> _loanContractPersonRepository;
        private readonly ILoanContractPersonsExcelExporter _loanContractPersonsExcelExporter;
        private readonly IRepository<Person, Guid> _lookup_personRepository;
        private readonly IRepository<LoanContract, Guid> _lookup_loanContractRepository;

        public LoanContractPersonsAppService(IRepository<LoanContractPerson, Guid> loanContractPersonRepository, ILoanContractPersonsExcelExporter loanContractPersonsExcelExporter, IRepository<Person, Guid> lookup_personRepository, IRepository<LoanContract, Guid> lookup_loanContractRepository)
        {
            _loanContractPersonRepository = loanContractPersonRepository;
            _loanContractPersonsExcelExporter = loanContractPersonsExcelExporter;
            _lookup_personRepository = lookup_personRepository;
            _lookup_loanContractRepository = lookup_loanContractRepository;

        }

        public virtual async Task<PagedResultDto<GetLoanContractPersonForViewDto>> GetAll(GetAllLoanContractPersonsInput input)
        {

            var filteredLoanContractPersons = _loanContractPersonRepository.GetAll()
                        .Include(e => e.PersonFk)
                        .Include(e => e.LoanContractFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PersonDisplayPropertyFilter), e => string.Format("{0}-{1}", e.PersonFk == null || e.PersonFk.FirstName == null ? "" : e.PersonFk.FirstName.ToString()
, e.PersonFk == null || e.PersonFk.LastName == null ? "" : e.PersonFk.LastName.ToString()
) == input.PersonDisplayPropertyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LoanContractSummeryFilter), e => e.LoanContractFk != null && e.LoanContractFk.Summery == input.LoanContractSummeryFilter);

            var pagedAndFilteredLoanContractPersons = filteredLoanContractPersons
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var loanContractPersons = from o in pagedAndFilteredLoanContractPersons
                                      join o1 in _lookup_personRepository.GetAll() on o.PersonId equals o1.Id into j1
                                      from s1 in j1.DefaultIfEmpty()

                                      join o2 in _lookup_loanContractRepository.GetAll() on o.LoanContractId equals o2.Id into j2
                                      from s2 in j2.DefaultIfEmpty()

                                      select new
                                      {

                                          Id = o.Id,
                                          PersonDisplayProperty = string.Format("{0}-{1}", s1 == null || s1.FirstName == null ? "" : s1.FirstName.ToString()
                      , s1 == null || s1.LastName == null ? "" : s1.LastName.ToString()
                      ),
                                          LoanContractSummery = s2 == null || s2.Summery == null ? "" : s2.Summery.ToString()
                                      };

            var totalCount = await filteredLoanContractPersons.CountAsync();

            var dbList = await loanContractPersons.ToListAsync();
            var results = new List<GetLoanContractPersonForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLoanContractPersonForViewDto()
                {
                    LoanContractPerson = new LoanContractPersonDto
                    {

                        Id = o.Id,
                    },
                    PersonDisplayProperty = o.PersonDisplayProperty,
                    LoanContractSummery = o.LoanContractSummery
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLoanContractPersonForViewDto>(
                totalCount,
                results
            );

        }

        public virtual async Task<GetLoanContractPersonForViewDto> GetLoanContractPersonForView(Guid id)
        {
            var loanContractPerson = await _loanContractPersonRepository.GetAsync(id);

            var output = new GetLoanContractPersonForViewDto { LoanContractPerson = ObjectMapper.Map<LoanContractPersonDto>(loanContractPerson) };

            if (output.LoanContractPerson.PersonId != null)
            {
                var _lookupPerson = await _lookup_personRepository.FirstOrDefaultAsync((Guid)output.LoanContractPerson.PersonId);
                output.PersonDisplayProperty = string.Format("{0}-{1}", _lookupPerson.FirstName, _lookupPerson.LastName);
            }

            if (output.LoanContractPerson.LoanContractId != null)
            {
                var _lookupLoanContract = await _lookup_loanContractRepository.FirstOrDefaultAsync((Guid)output.LoanContractPerson.LoanContractId);
                output.LoanContractSummery = _lookupLoanContract?.Summery?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons_Edit)]
        public virtual async Task<GetLoanContractPersonForEditOutput> GetLoanContractPersonForEdit(EntityDto<Guid> input)
        {
            var loanContractPerson = await _loanContractPersonRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLoanContractPersonForEditOutput { LoanContractPerson = ObjectMapper.Map<CreateOrEditLoanContractPersonDto>(loanContractPerson) };

            if (output.LoanContractPerson.PersonId != null)
            {
                var _lookupPerson = await _lookup_personRepository.FirstOrDefaultAsync((Guid)output.LoanContractPerson.PersonId);
                output.PersonDisplayProperty = string.Format("{0}-{1}", _lookupPerson.FirstName, _lookupPerson.LastName);
            }

            if (output.LoanContractPerson.LoanContractId != null)
            {
                var _lookupLoanContract = await _lookup_loanContractRepository.FirstOrDefaultAsync((Guid)output.LoanContractPerson.LoanContractId);
                output.LoanContractSummery = _lookupLoanContract?.Summery?.ToString();
            }

            return output;
        }

        public virtual async Task CreateOrEdit(CreateOrEditLoanContractPersonDto input)
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

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons_Create)]
        protected virtual async Task Create(CreateOrEditLoanContractPersonDto input)
        {
            var loanContractPerson = ObjectMapper.Map<LoanContractPerson>(input);

            await _loanContractPersonRepository.InsertAsync(loanContractPerson);

        }

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons_Edit)]
        protected virtual async Task Update(CreateOrEditLoanContractPersonDto input)
        {
            var loanContractPerson = await _loanContractPersonRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, loanContractPerson);

        }

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons_Delete)]
        public virtual async Task Delete(EntityDto<Guid> input)
        {
            await _loanContractPersonRepository.DeleteAsync(input.Id);
        }

        public virtual async Task<FileDto> GetLoanContractPersonsToExcel(GetAllLoanContractPersonsForExcelInput input)
        {

            var filteredLoanContractPersons = _loanContractPersonRepository.GetAll()
                        .Include(e => e.PersonFk)
                        .Include(e => e.LoanContractFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PersonDisplayPropertyFilter), e => string.Format("{0}-{1}", e.PersonFk == null || e.PersonFk.FirstName == null ? "" : e.PersonFk.FirstName.ToString()
, e.PersonFk == null || e.PersonFk.LastName == null ? "" : e.PersonFk.LastName.ToString()
) == input.PersonDisplayPropertyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LoanContractSummeryFilter), e => e.LoanContractFk != null && e.LoanContractFk.Summery == input.LoanContractSummeryFilter);

            var query = (from o in filteredLoanContractPersons
                         join o1 in _lookup_personRepository.GetAll() on o.PersonId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_loanContractRepository.GetAll() on o.LoanContractId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetLoanContractPersonForViewDto()
                         {
                             LoanContractPerson = new LoanContractPersonDto
                             {
                                 Id = o.Id
                             },
                             PersonDisplayProperty = string.Format("{0}-{1}", s1 == null || s1.FirstName == null ? "" : s1.FirstName.ToString()
, s1 == null || s1.LastName == null ? "" : s1.LastName.ToString()
),
                             LoanContractSummery = s2 == null || s2.Summery == null ? "" : s2.Summery.ToString()
                         });

            var loanContractPersonListDtos = await query.ToListAsync();

            return _loanContractPersonsExcelExporter.ExportToFile(loanContractPersonListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons)]
        public async Task<List<LoanContractPersonPersonLookupTableDto>> GetAllPersonForTableDropdown()
        {
            return await _lookup_personRepository.GetAll()
                .Select(person => new LoanContractPersonPersonLookupTableDto
                {
                    Id = person.Id.ToString(),
                    DisplayName = string.Format("{0}-{1}", person.FirstName, person.LastName)
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContractPersons)]
        public async Task<List<LoanContractPersonLoanContractLookupTableDto>> GetAllLoanContractForTableDropdown()
        {
            return await _lookup_loanContractRepository.GetAll()
                .Select(loanContract => new LoanContractPersonLoanContractLookupTableDto
                {
                    Id = loanContract.Id.ToString(),
                    DisplayName = loanContract == null || loanContract.Summery == null ? "" : loanContract.Summery.ToString()
                }).ToListAsync();
        }

    }
}