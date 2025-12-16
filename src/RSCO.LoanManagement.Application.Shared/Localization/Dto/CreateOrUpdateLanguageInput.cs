using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}