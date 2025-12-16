using System.Collections.Generic;
using Abp.Localization;
using RSCO.LoanManagement.Install.Dto;

namespace RSCO.LoanManagement.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
