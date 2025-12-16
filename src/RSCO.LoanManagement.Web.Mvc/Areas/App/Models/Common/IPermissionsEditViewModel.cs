using System.Collections.Generic;
using RSCO.LoanManagement.Authorization.Permissions.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}