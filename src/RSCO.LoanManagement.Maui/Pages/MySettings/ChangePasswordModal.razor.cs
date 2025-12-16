using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RSCO.LoanManagement.Authorization.Users.Profile;
using RSCO.LoanManagement.Authorization.Users.Profile.Dto;
using RSCO.LoanManagement.Maui.Core;
using RSCO.LoanManagement.Maui.Core.Components;
using RSCO.LoanManagement.Maui.Core.Threading;
using RSCO.LoanManagement.Maui.Models.Settings;

namespace RSCO.LoanManagement.Maui.Pages.MySettings
{
    public partial class ChangePasswordModal : ModalBase
    {
        [Parameter] public EventCallback OnSave { get; set; }

        public override string ModalId => "change-password";

        public ChangePasswordModel ChangePasswordModel { get; set; } = new();
        
        private readonly IProfileAppService _profileAppService;

        public ChangePasswordModal()
        {
            _profileAppService = Resolve<IProfileAppService>();
        }

        public override Task Hide()
        {
            ChangePasswordModel = new ChangePasswordModel();
            return base.Hide();
        }

        protected virtual async Task Save()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(async () =>
                {
                    await _profileAppService.ChangePassword(new ChangePasswordInput
                    {
                        CurrentPassword = ChangePasswordModel.CurrentPassword,
                        NewPassword = ChangePasswordModel.NewPassword
                    });
                }, async () => await OnSave.InvokeAsync());
            });
        }

        protected virtual async Task Cancel()
        {
            await Hide();
        }
    }
}