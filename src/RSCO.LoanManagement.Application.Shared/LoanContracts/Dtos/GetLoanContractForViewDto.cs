namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class GetLoanContractForViewDto
    {
        public LoanContractDto LoanContract { get; set; }

        public string BorrowerName { get; set; }

        public string GuarantorNames { get; set; }

    }
}
