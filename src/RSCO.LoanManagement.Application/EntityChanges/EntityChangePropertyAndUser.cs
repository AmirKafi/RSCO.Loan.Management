using Abp.EntityHistory;
using RSCO.LoanManagement.Authorization.Users;
using System.Collections.Generic;

namespace RSCO.LoanManagement.EntityChanges
{
    public class EntityChangePropertyAndUser
    {
        public EntityChange EntityChange { get; set; }
        public List<EntityPropertyChange> PropertyChanges { get; set; }
        public User User { get; set; }
    }
}
