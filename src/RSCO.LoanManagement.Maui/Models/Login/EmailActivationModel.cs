using System.ComponentModel.DataAnnotations;
using RSCO.LoanManagement.Validation;

namespace RSCO.LoanManagement.Maui.Models.Login
{
    public class EmailActivationModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
