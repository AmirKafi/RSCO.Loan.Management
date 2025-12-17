using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.LoanContracts.Dtos;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.LoanContracts
{
    public interface ILoanContractsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLoanContractForViewDto>> GetAll(GetAllLoanContractsInput input);

        Task<GetLoanContractForViewDto> GetLoanContractForView(Guid id);

        Task<GetLoanContractForEditOutput> GetLoanContractForEdit(EntityDto<Guid> input);

        Task CreateOrEdit(CreateOrEditLoanContractDto input);

        Task Delete(EntityDto<Guid> input);

        Task<FileDto> GetLoanContractsToExcel(GetAllLoanContractsForExcelInput input);

    }
}