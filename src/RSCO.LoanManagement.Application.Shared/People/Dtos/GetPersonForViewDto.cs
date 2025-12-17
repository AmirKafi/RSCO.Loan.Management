using System.Collections.Generic;
using RSCO.LoanManagement.LoanContracts.Dtos;

namespace RSCO.LoanManagement.People.Dtos
{
    public class GetPersonForViewDto
    {
        public PersonDto Person { get; set; }

        public List<LoanContractDto> BorrowerLoanContracts { get; set; }

        public List<LoanContractDto> GuarantorLoanContracts { get; set; }
    }
}
