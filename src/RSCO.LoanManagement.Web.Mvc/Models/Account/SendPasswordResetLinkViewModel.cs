using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}