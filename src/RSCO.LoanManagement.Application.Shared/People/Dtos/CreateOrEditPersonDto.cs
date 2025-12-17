using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.People.Dtos
{
    public class CreateOrEditPersonDto : EntityDto<Guid?>
    {

        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength)]
        public string LastName { get; set; }

    }
}