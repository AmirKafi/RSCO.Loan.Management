using System.Globalization;

namespace RSCO.LoanManagement.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}