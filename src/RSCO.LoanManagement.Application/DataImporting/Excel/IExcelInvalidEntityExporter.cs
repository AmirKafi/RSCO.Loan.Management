using System.Collections.Generic;
using Abp.Dependency;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.DataImporting.Excel;

public interface IExcelInvalidEntityExporter<TEntityDto> : ITransientDependency
{
    FileDto ExportToFile(List<TEntityDto> entities);
}