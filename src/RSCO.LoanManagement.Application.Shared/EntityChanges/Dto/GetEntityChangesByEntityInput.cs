using RSCO.LoanManagement.Dto;
using System;

namespace RSCO.LoanManagement.EntityChanges.Dto
{
    public class GetEntityChangesByEntityInput
    {
        public string EntityTypeFullName { get; set; }
        public string EntityId { get; set; }
    }
}
