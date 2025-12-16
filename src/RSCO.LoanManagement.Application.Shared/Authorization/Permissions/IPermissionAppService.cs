using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization.Permissions.Dto;

namespace RSCO.LoanManagement.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
