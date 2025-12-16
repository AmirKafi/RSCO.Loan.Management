using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.Maui.Models.Login
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
    }
}
