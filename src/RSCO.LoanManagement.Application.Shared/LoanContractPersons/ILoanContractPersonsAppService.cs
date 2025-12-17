using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.LoanContractPersons.Dtos;
using RSCO.LoanManagement.Dto;
using System.Collections.Generic;
using System.Collections.Generic;

namespace RSCO.LoanManagement.LoanContractPersons
{
    public interface ILoanContractPersonsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLoanContractPersonForViewDto>> GetAll(GetAllLoanContractPersonsInput input);

        Task<GetLoanContractPersonForViewDto> GetLoanContractPersonForView(Guid id);

        Task<GetLoanContractPersonForEditOutput> GetLoanContractPersonForEdit(EntityDto<Guid> input);

        Task CreateOrEdit(CreateOrEditLoanContractPersonDto input);

        Task Delete(EntityDto<Guid> input);

        Task<FileDto> GetLoanContractPersonsToExcel(GetAllLoanContractPersonsForExcelInput input);

        Task<List<LoanContractPersonPersonLookupTableDto>> GetAllPersonForTableDropdown();

        Task<List<LoanContractPersonLoanContractLookupTableDto>> GetAllLoanContractForTableDropdown();

    }
}