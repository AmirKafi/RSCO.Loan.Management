using System.Threading.Tasks;

namespace RSCO.LoanManagement.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}