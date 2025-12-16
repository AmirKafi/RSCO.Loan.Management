using System.Collections.Generic;

namespace RSCO.LoanManagement.DataExporting
{
    public interface IExcelColumnSelectionInput
    {
        List<string> SelectedColumns { get; set; }
    }
}