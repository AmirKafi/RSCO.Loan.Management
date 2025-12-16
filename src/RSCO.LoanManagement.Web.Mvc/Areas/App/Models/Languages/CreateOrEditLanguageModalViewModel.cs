using Abp.AutoMapper;
using RSCO.LoanManagement.Localization.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}