using System.Threading.Tasks;
using RSCO.LoanManagement.Security.Recaptcha;

namespace RSCO.LoanManagement.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
