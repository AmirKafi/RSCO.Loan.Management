using Abp.AutoMapper;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Maui.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}