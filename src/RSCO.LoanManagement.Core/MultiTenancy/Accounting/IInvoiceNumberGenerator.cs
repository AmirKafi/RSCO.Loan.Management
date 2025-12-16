using System.Threading.Tasks;
using Abp.Dependency;

namespace RSCO.LoanManagement.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}