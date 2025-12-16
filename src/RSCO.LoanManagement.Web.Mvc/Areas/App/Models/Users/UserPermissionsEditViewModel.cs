using Abp.AutoMapper;
using RSCO.LoanManagement.Authorization.Users;
using RSCO.LoanManagement.Authorization.Users.Dto;
using RSCO.LoanManagement.Web.Areas.App.Models.Common;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}