using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace RSCO.LoanManagement.People
{
    [Table("People")]
    public class Person : AuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength, MinimumLength = PersonConsts.MinFirstNameLength)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength, MinimumLength = PersonConsts.MinLastNameLength)]
        public virtual string LastName { get; set; }

    }
}