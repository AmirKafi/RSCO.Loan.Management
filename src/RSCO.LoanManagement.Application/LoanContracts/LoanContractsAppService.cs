using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using RSCO.LoanManagement.LoanContracts.Exporting;
using RSCO.LoanManagement.LoanContracts.Dtos;
using RSCO.LoanManagement.Dto;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using RSCO.LoanManagement.Storage;
using RSCO.LoanManagement.LoanContractPersons;

namespace RSCO.LoanManagement.LoanContracts
{
    [AbpAuthorize(AppPermissions.Pages_LoanContracts)]
    public class LoanContractsAppService : LoanManagementAppServiceBase, ILoanContractsAppService
    {
        private readonly IRepository<LoanContract, Guid> _loanContractRepository;
        private readonly ILoanContractsExcelExporter _loanContractsExcelExporter;

        public LoanContractsAppService(IRepository<LoanContract, Guid> loanContractRepository, ILoanContractsExcelExporter loanContractsExcelExporter)
        {
            _loanContractRepository = loanContractRepository;
            _loanContractsExcelExporter = loanContractsExcelExporter;

        }

        public virtual async Task<PagedResultDto<GetLoanContractForViewDto>> GetAll(GetAllLoanContractsInput input)
        {

            var filteredLoanContracts = _loanContractRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Summery.Contains(input.Filter))
                        .WhereIf(input.MinContractDateFilter != null, e => e.ContractDate >= input.MinContractDateFilter)
                        .WhereIf(input.MaxContractDateFilter != null, e => e.ContractDate <= input.MaxContractDateFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SummeryFilter), e => e.Summery.Contains(input.SummeryFilter));

            var pagedAndFilteredLoanContracts = filteredLoanContracts
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var dbList = await pagedAndFilteredLoanContracts
                .Include(x => x.Persons)
                .ThenInclude(x => x.Person)
                .ToListAsync();

            var totalCount = await filteredLoanContracts.CountAsync();

            var results = new List<GetLoanContractForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLoanContractForViewDto()
                {
                    LoanContract = new LoanContractDto
                    {
                        ContractDate = o.ContractDate,
                        Amount = o.Amount,
                        Summery = o.Summery,
                        Id = o.Id,
                    }
                };
                
                var borrower = o.Persons.FirstOrDefault(p => p.Role == LoanContractPersonRole.Borrower);
                if (borrower?.Person != null)
                {
                    res.BorrowerName = borrower.Person.FirstName + " " + borrower.Person.LastName;
                }

                var guarantors = o.Persons
                    .Where(p => p.Role == LoanContractPersonRole.Guarantor && p.Person != null)
                    .Select(p => p.Person.FirstName + " " + p.Person.LastName)
                    .ToList();
                
                res.GuarantorNames = string.Join(", ", guarantors);

                results.Add(res);
            }

            return new PagedResultDto<GetLoanContractForViewDto>(
                totalCount,
                results
            );

        }

        public virtual async Task<GetLoanContractForViewDto> GetLoanContractForView(Guid id)
        {
            var loanContract = await _loanContractRepository.GetAll()
                .Include(x => x.Persons)
                .ThenInclude(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);

            var output = new GetLoanContractForViewDto { LoanContract = ObjectMapper.Map<LoanContractDto>(loanContract) };

            if (loanContract != null)
            {
                var borrower = loanContract.Persons.FirstOrDefault(p => p.Role == LoanContractPersonRole.Borrower);
                if (borrower?.Person != null)
                {
                    output.BorrowerName = borrower.Person.FirstName + " " + borrower.Person.LastName;
                }

                var guarantors = loanContract.Persons
                    .Where(p => p.Role == LoanContractPersonRole.Guarantor && p.Person != null)
                    .Select(p => p.Person.FirstName + " " + p.Person.LastName)
                    .ToList();
                
                output.GuarantorNames = string.Join(", ", guarantors);
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Edit)]
        public virtual async Task<GetLoanContractForEditOutput> GetLoanContractForEdit(EntityDto<Guid> input)
        {
            var loanContract = await _loanContractRepository.GetAll()
                .Include(x => x.Persons)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            var output = new GetLoanContractForEditOutput { LoanContract = ObjectMapper.Map<CreateOrEditLoanContractDto>(loanContract) };

            if (loanContract != null)
            {
                var borrower = loanContract.Persons.FirstOrDefault(p => p.Role == LoanContractPersonRole.Borrower);
                output.LoanContract.BorrowerId = borrower?.PersonId;

                output.LoanContract.GuarantorIds = loanContract.Persons
                    .Where(p => p.Role == LoanContractPersonRole.Guarantor)
                    .Select(p => p.PersonId)
                    .ToList();
            }

            return output;
        }

        public virtual async Task CreateOrEdit(CreateOrEditLoanContractDto input)
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

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Create)]
        protected virtual async Task Create(CreateOrEditLoanContractDto input)
        {
            var loanContract = ObjectMapper.Map<LoanContract>(input);
            loanContract.Id = Guid.NewGuid();

            if (input.BorrowerId.HasValue)
            {
                loanContract.AddPerson(input.BorrowerId.Value, LoanContractPersonRole.Borrower);
            }

            if (input.GuarantorIds != null)
            {
                foreach (var guarantorId in input.GuarantorIds)
                {
                    loanContract.AddPerson(guarantorId, LoanContractPersonRole.Guarantor);
                }
            }

            await _loanContractRepository.InsertAsync(loanContract);

        }

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Edit)]
        protected virtual async Task Update(CreateOrEditLoanContractDto input)
        {
            var loanContract = await _loanContractRepository.GetAllIncluding(x => x.Persons)
                                                            .FirstOrDefaultAsync(x => x.Id == (Guid)input.Id);
            ObjectMapper.Map(input, loanContract);

            // Update Borrower
            var existingBorrower = loanContract.Persons.FirstOrDefault(p => p.Role == LoanContractPersonRole.Borrower);
            if (input.BorrowerId.HasValue)
            {
                if (existingBorrower == null)
                {
                    loanContract.AddPerson(input.BorrowerId.Value, LoanContractPersonRole.Borrower);
                }
                else if (existingBorrower.PersonId != input.BorrowerId.Value)
                {
                    loanContract.Persons.Remove(existingBorrower);
                    loanContract.AddPerson(input.BorrowerId.Value, LoanContractPersonRole.Borrower);
                }
            }
            else if (existingBorrower != null)
            {
                loanContract.Persons.Remove(existingBorrower);
            }

            // Update Guarantors
            var existingGuarantors = loanContract.Persons.Where(p => p.Role == LoanContractPersonRole.Guarantor).ToList();
            var newGuarantorIds = input.GuarantorIds ?? new List<Guid>();

            // Remove deleted guarantors
            foreach (var existingGuarantor in existingGuarantors)
            {
                if (!newGuarantorIds.Contains(existingGuarantor.PersonId))
                {
                    loanContract.Persons.Remove(existingGuarantor);
                }
            }

            // Add new guarantors
            foreach (var newGuarantorId in newGuarantorIds)
            {
                if (!existingGuarantors.Any(p => p.PersonId == newGuarantorId))
                {
                    loanContract.AddPerson(newGuarantorId, LoanContractPersonRole.Guarantor);
                }
            }
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Delete)]
        public virtual async Task Delete(EntityDto<Guid> input)
        {
            await _loanContractRepository.DeleteAsync(input.Id);
        }

        public virtual async Task<FileDto> GetLoanContractsToExcel(GetAllLoanContractsForExcelInput input)
        {

            var filteredLoanContracts = _loanContractRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Summery.Contains(input.Filter))
                        .WhereIf(input.MinContractDateFilter != null, e => e.ContractDate >= input.MinContractDateFilter)
                        .WhereIf(input.MaxContractDateFilter != null, e => e.ContractDate <= input.MaxContractDateFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SummeryFilter), e => e.Summery.Contains(input.SummeryFilter));

            var query = (from o in filteredLoanContracts
                         select new GetLoanContractForViewDto()
                         {
                             LoanContract = new LoanContractDto
                             {
                                 ContractDate = o.ContractDate,
                                 Amount = o.Amount,
                                 Summery = o.Summery,
                                 Id = o.Id
                             }
                         });

            var loanContractListDtos = await query.ToListAsync();

            return _loanContractsExcelExporter.ExportToFile(loanContractListDtos);
        }

    }
}