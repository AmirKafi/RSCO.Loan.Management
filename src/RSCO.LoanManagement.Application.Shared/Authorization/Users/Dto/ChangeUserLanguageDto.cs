using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
