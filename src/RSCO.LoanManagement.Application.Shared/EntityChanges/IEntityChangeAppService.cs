using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.EntityChanges.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSCO.LoanManagement.EntityChanges
{
    public interface IEntityChangeAppService : IApplicationService
    {
        Task<ListResultDto<EntityAndPropertyChangeListDto>> GetEntityChangesByEntity(GetEntityChangesByEntityInput input);
    }
}
