using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RSCO.LoanManagement.ApiClient;
using RSCO.LoanManagement.Maui.Core;

namespace RSCO.LoanManagement.Maui
{
    [DependsOn(typeof(RSCO.LoanManagementClientModule), typeof(AbpAutoMapperModule))]
    public class RSCO.LoanManagementMauiModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.ReplaceService<IApplicationContext, MauiApplicationContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RSCO.LoanManagementMauiModule).GetAssembly());
        }
    }
}