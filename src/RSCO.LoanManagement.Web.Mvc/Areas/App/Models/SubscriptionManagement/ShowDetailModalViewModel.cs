using Abp.AutoMapper;
using RSCO.LoanManagement.MultiTenancy.Payments.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.SubscriptionManagement;

[AutoMapFrom(typeof(SubscriptionPaymentProductDto))]
public class ShowDetailModalViewModel : SubscriptionPaymentProductDto
{
}