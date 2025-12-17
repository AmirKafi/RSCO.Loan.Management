using RSCO.LoanManagement.People.Dtos;

using Abp.Extensions;

namespace RSCO.LoanManagement.Web.Areas.App.Models.People
{
    public class CreateOrEditPersonViewModel
    {
        public CreateOrEditPersonDto Person { get; set; }

        public bool IsEditMode => Person.Id.HasValue;
    }
}