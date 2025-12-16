using System.Collections.Generic;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Editions.Dto;

namespace RSCO.LoanManagement.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}