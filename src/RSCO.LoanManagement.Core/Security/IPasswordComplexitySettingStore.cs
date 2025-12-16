using System.Threading.Tasks;

namespace RSCO.LoanManagement.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
