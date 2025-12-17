using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.People.Dtos
{
    public class CreateOrEditPersonDto : EntityDto<Guid?>
    {

        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength, MinimumLength = PersonConsts.MinFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength, MinimumLength = PersonConsts.MinLastNameLength)]
        public string LastName { get; set; }

    }
}