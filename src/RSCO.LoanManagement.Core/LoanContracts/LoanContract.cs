using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using RSCO.LoanManagement.LoanContractPersons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSCO.LoanManagement.LoanContracts
{
    [Table("LoanContracts")]
    public class LoanContract : AuditedEntity<Guid>
    {

        public virtual DateTime ContractDate { get; set; }

        public virtual decimal Amount { get; set; }

        [Required]
        public virtual string Summery { get; set; }

        public ICollection<LoanContractPerson> Persons { get; set; } = new List<LoanContractPerson>();
    }
}