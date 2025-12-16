using RSCO.LoanManagement.Maui.Models.NavigationMenu;

namespace RSCO.LoanManagement.Maui.Services.Navigation
{
    public interface IMenuProvider
    {
        List<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}