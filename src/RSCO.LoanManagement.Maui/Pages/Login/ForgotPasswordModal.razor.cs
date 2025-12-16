using Microsoft.AspNetCore.Components;
using RSCO.LoanManagement.Authorization.Accounts;
using RSCO.LoanManagement.Authorization.Accounts.Dto;
using RSCO.LoanManagement.Maui.Core;
using RSCO.LoanManagement.Maui.Core.Components;
using RSCO.LoanManagement.Maui.Core.Threading;
using RSCO.LoanManagement.Maui.Models.Login;

namespace RSCO.LoanManagement.Maui.Pages.Login
{
    public partial class ForgotPasswordModal : ModalBase
    {
        public override string ModalId => "forgot-password-modal";
       
        [Parameter] public EventCallback OnSave { get; set; }
        
        public ForgotPasswordModel ForgotPasswordModel { get; } = new();

        private readonly IAccountAppService _accountAppService;

        public ForgotPasswordModal()
        {
            _accountAppService = Resolve<IAccountAppService>();
        }

        protected virtual async Task Save()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(
                async () =>
                    await _accountAppService.SendPasswordResetCode(new SendPasswordResetCodeInput { EmailAddress = ForgotPasswordModel.EmailAddress }),
                    async () =>
                    {
                        await OnSave.InvokeAsync();
                    }
                );
            });
        }

        protected virtual async Task Cancel()
        {
            await Hide();
        }
    }
}
