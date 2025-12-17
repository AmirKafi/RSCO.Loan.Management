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
        public Guid PersonId { get; protected set; }

        public Guid LoanContractId { get; protected set; }

        public LoanContractPersonRole Role { get; protected set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("LoanContractId")]
        public virtual LoanContract LoanContract { get; set; }

        protected LoanContractPerson() { }

        public LoanContractPerson(Guid loanContractId, Guid personId, LoanContractPersonRole role)
        {
            LoanContractId = loanContractId;
            PersonId = personId;
            Role = role;
        }
    }
}