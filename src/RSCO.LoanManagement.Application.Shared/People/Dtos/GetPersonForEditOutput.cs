using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.People.Dtos
{
    public class GetPersonForEditOutput
    {
        public CreateOrEditPersonDto Person { get; set; }

    }
}