using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.People.Dtos;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.People
{
    public interface IPeopleAppService : IApplicationService
    {
        Task<PagedResultDto<GetPersonForViewDto>> GetAll(GetAllPeopleInput input);

        Task<GetPersonForViewDto> GetPersonForView(Guid id);

        Task<GetPersonForEditOutput> GetPersonForEdit(EntityDto<Guid> input);

        Task CreateOrEdit(CreateOrEditPersonDto input);

        Task Delete(EntityDto<Guid> input);

        Task<FileDto> GetPeopleToExcel(GetAllPeopleForExcelInput input);

    }
}