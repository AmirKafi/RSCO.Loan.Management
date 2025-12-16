using System.Collections.Generic;
using RSCO.LoanManagement.Authorization.Delegation;
using RSCO.LoanManagement.Authorization.Users.Delegation.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
