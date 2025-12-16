using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace RSCO.LoanManagement.Net.Emailing
{
    public class LoanManagementSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public LoanManagementSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}