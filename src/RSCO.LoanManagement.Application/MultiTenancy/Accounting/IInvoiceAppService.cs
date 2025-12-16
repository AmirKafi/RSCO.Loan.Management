using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.MultiTenancy.Accounting.Dto;

namespace RSCO.LoanManagement.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
