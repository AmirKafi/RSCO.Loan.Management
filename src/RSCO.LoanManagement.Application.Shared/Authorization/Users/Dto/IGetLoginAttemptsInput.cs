using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}