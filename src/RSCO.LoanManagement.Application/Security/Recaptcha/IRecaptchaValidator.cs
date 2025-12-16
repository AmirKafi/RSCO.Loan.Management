using System.Threading.Tasks;

namespace RSCO.LoanManagement.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}