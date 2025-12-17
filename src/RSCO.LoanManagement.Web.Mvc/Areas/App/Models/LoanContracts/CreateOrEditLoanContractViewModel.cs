using RSCO.LoanManagement.LoanContracts.Dtos;

using Abp.Extensions;

namespace RSCO.LoanManagement.Web.Areas.App.Models.LoanContracts
{
    public class CreateOrEditLoanContractViewModel
    {
        public CreateOrEditLoanContractDto LoanContract { get; set; }

        public bool IsEditMode => LoanContract.Id.HasValue;
    }
}