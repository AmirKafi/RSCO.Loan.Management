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

            var loanContracts = from o in pagedAndFilteredLoanContracts
                                select new
                                {

                                    o.ContractDate,
                                    o.Amount,
                                    o.Summery,
                                    Id = o.Id
                                };

            var totalCount = await filteredLoanContracts.CountAsync();

            var dbList = await loanContracts.ToListAsync();
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

                results.Add(res);
            }

            return new PagedResultDto<GetLoanContractForViewDto>(
                totalCount,
                results
            );

        }

        public virtual async Task<GetLoanContractForViewDto> GetLoanContractForView(Guid id)
        {
            var loanContract = await _loanContractRepository.GetAsync(id);

            var output = new GetLoanContractForViewDto { LoanContract = ObjectMapper.Map<LoanContractDto>(loanContract) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Edit)]
        public virtual async Task<GetLoanContractForEditOutput> GetLoanContractForEdit(EntityDto<Guid> input)
        {
            var loanContract = await _loanContractRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLoanContractForEditOutput { LoanContract = ObjectMapper.Map<CreateOrEditLoanContractDto>(loanContract) };

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

            await _loanContractRepository.InsertAsync(loanContract);

        }

        [AbpAuthorize(AppPermissions.Pages_LoanContracts_Edit)]
        protected virtual async Task Update(CreateOrEditLoanContractDto input)
        {
            var loanContract = await _loanContractRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, loanContract);

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