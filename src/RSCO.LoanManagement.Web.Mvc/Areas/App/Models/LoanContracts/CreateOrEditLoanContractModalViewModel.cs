using RSCO.LoanManagement.LoanContracts.Dtos;
using System.Collections.Generic;
using RSCO.LoanManagement.People.Dtos;
using Abp.Extensions;

namespace RSCO.LoanManagement.Web.Areas.App.Models.LoanContracts
{
    public class CreateOrEditLoanContractModalViewModel
    {
        public CreateOrEditLoanContractDto LoanContract { get; set; }

        public List<PersonDto> PersonList { get; set; }

        public bool IsEditMode => LoanContract.Id.HasValue;
    }
}