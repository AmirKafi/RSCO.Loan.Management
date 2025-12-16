using Abp.AutoMapper;
using RSCO.LoanManagement.Authorization.Users.Dto;

namespace RSCO.LoanManagement.Maui.Models.User
{
    [AutoMapFrom(typeof(UserListDto))]
    public class UserListModel : UserListDto
    {
        public string Photo { get; set; }

        public string FullName => Name + " " + Surname;
    }
}
