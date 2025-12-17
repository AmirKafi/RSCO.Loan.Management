using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using RSCO.LoanManagement.LoanContractPersons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSCO.LoanManagement.People
{
    [Table("People")]
    public class Person : AuditedEntity<Guid>
    {
        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength)]
        public virtual string LastName { get; set; }

        public ICollection<LoanContractPerson> LoanContracts { get; set; } = new List<LoanContractPerson>();
    }
}