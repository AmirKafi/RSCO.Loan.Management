using Abp.Dependency;

namespace RSCO.LoanManagement.Web.Xss
{
    public interface IHtmlSanitizer: ITransientDependency
    {
        string Sanitize(string html);
    }
}