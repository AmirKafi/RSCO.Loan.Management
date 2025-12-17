using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Web.Areas.App.Models.People;
using RSCO.LoanManagement.Web.Controllers;
using RSCO.LoanManagement.Authorization;
using RSCO.LoanManagement.People;
using RSCO.LoanManagement.People.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace RSCO.LoanManagement.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_People)]
    public class PeopleController : LoanManagementControllerBase
    {
        private readonly IPeopleAppService _peopleAppService;

        public PeopleController(IPeopleAppService peopleAppService)
        {
            _peopleAppService = peopleAppService;

        }

        public ActionResult Index()
        {
            var model = new PeopleViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_People_Create, AppPermissions.Pages_People_Edit)]
        public async Task<ActionResult> CreateOrEdit(Guid? id)
        {
            GetPersonForEditOutput getPersonForEditOutput;

            if (id.HasValue)
            {
                getPersonForEditOutput = await _peopleAppService.GetPersonForEdit(new EntityDto<Guid> { Id = (Guid)id });
            }
            else
            {
                getPersonForEditOutput = new GetPersonForEditOutput
                {
                    Person = new CreateOrEditPersonDto()
                };
            }

            var viewModel = new CreateOrEditPersonViewModel()
            {
                Person = getPersonForEditOutput.Person,
            };

            return View(viewModel);
        }

        public async Task<ActionResult> ViewPerson(Guid id)
        {
            var dto = await _peopleAppService.GetPersonForView(id);
            var model = new PersonViewModel()
            {
                Person = dto.Person,
                BorrowerLoanContracts = dto.BorrowerLoanContracts,
                GuarantorLoanContracts = dto.GuarantorLoanContracts
            };
            return View(model);
        }

    }
}
