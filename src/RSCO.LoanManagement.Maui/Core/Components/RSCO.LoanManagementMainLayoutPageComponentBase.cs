using RSCO.LoanManagement.Maui.Services.UI;

namespace RSCO.LoanManagement.Maui.Core.Components
{
    public class RSCO.LoanManagementMainLayoutPageComponentBase : RSCO.LoanManagementComponentBase
    {
        protected PageHeaderService PageHeaderService { get; set; }

        protected DomManipulatorService DomManipulatorService { get; set; }

        public RSCO.LoanManagementMainLayoutPageComponentBase()
        {
            PageHeaderService = Resolve<PageHeaderService>();
            DomManipulatorService = Resolve<DomManipulatorService>();
        }

        protected async Task SetPageHeader(string title)
        {
            PageHeaderService.Title = title;
            PageHeaderService.ClearButton();
            await DomManipulatorService.ClearModalBackdrop(JS);
        }

        protected async Task SetPageHeader(string title, List<PageHeaderButton> buttons)
        {
            PageHeaderService.Title = title;
            PageHeaderService.SetButtons(buttons);
            await DomManipulatorService.ClearModalBackdrop(JS);
        }
    }
}
