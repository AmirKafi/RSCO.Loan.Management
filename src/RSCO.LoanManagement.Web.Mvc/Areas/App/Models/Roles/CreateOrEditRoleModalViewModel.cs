using Abp.AutoMapper;
using RSCO.LoanManagement.Authorization.Roles.Dto;
using RSCO.LoanManagement.Web.Areas.App.Models.Common;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}