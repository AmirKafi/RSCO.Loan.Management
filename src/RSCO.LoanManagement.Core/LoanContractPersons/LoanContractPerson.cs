using RSCO.LoanManagement.People;
using RSCO.LoanManagement.LoanContracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace RSCO.LoanManagement.LoanContractPersons
{
    [Table("LoanContractPersons")]
    public class LoanContractPerson : AuditedEntity<Guid>
    {

        public virtual Guid PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person PersonFk { get; set; }

        public virtual Guid LoanContractId { get; set; }

        [ForeignKey("LoanContractId")]
        public LoanContract LoanContractFk { get; set; }

    }
}