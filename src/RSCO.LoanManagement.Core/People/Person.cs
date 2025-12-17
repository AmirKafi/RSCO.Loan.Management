using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using RSCO.LoanManagement.LoanContractPersons;
using System.Collections.Generic;

namespace RSCO.LoanManagement.People
{
    [Table("People")]
    public class Person : AuditedEntity<Guid>
    {
        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength, MinimumLength = PersonConsts.MinFirstNameLength)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength, MinimumLength = PersonConsts.MinLastNameLength)]
        public virtual string LastName { get; set; }

        public ICollection<LoanContractPerson> LoanContracts { get; set; } = new List<LoanContractPerson>();
    }
}