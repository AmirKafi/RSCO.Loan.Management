using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using RSCO.LoanManagement.DataExporting.Excel.MiniExcel;
using RSCO.LoanManagement.LoanContractPersons.Dtos;
using RSCO.LoanManagement.Dto;
using RSCO.LoanManagement.Storage;

namespace RSCO.LoanManagement.LoanContractPersons.Exporting
{
    public class LoanContractPersonsExcelExporter : MiniExcelExcelExporterBase, ILoanContractPersonsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LoanContractPersonsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetLoanContractPersonForViewDto> loanContractPersons)
        {

            var items = new List<Dictionary<string, object>>();

            foreach (var loanContractPerson in loanContractPersons)
            {
                items.Add(new Dictionary<string, object>()
                {

                });
            }

            return CreateExcelPackage("LoanContractPersonsList.xlsx", items);

        }
    }
}