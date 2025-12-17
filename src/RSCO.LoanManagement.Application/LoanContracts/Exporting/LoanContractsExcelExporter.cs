using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using RSCO.LoanManagement.DataExporting.Excel.MiniExcel;
using RSCO.LoanManagement.LoanContracts.Dtos;
using RSCO.LoanManagement.Dto;
using RSCO.LoanManagement.Storage;

namespace RSCO.LoanManagement.LoanContracts.Exporting
{
    public class LoanContractsExcelExporter : MiniExcelExcelExporterBase, ILoanContractsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LoanContractsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetLoanContractForViewDto> loanContracts)
        {

            var items = new List<Dictionary<string, object>>();

            foreach (var loanContract in loanContracts)
            {
                items.Add(new Dictionary<string, object>()
                    {
                        {L("ContractDate"), loanContract.LoanContract.ContractDate},
                        {L("Amount"), loanContract.LoanContract.Amount},
                        {L("Summery"), loanContract.LoanContract.Summery},

                    });
            }

            return CreateExcelPackage("LoanContractsList.xlsx", items);

        }
    }
}