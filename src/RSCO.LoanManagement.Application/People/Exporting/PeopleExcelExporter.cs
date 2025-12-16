using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using RSCO.LoanManagement.DataExporting.Excel.MiniExcel;
using RSCO.LoanManagement.People.Dtos;
using RSCO.LoanManagement.Dto;
using RSCO.LoanManagement.Storage;

namespace RSCO.LoanManagement.People.Exporting
{
    public class PeopleExcelExporter : MiniExcelExcelExporterBase, IPeopleExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PeopleExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPersonForViewDto> people)
        {

            var items = new List<Dictionary<string, object>>();

            foreach (var person in people)
            {
                items.Add(new Dictionary<string, object>()
                    {
                        {L("FirstName"), person.Person.FirstName},
                        {L("LastName"), person.Person.LastName},

                    });
            }

            return CreateExcelPackage("PeopleList.xlsx", items);

        }
    }
}