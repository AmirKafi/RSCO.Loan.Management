using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Web.Areas.App.Models.LoanContracts;
using RSCO.LoanManagement.Web.Controllers;
using RSCO.LoanManagement.Authorization;
using RSCO.LoanManagement.LoanContracts;
using RSCO.LoanManagement.LoanContracts.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using RSCO.LoanManagement.People;

namespace RSCO.LoanManagement.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_LoanContracts)]
    public class LoanContractsController : LoanManagementControllerBase
    {
        private readonly ILoanContractsAppService _loanContractsAppService;
        private readonly IPeopleAppService _peopleAppService;

        public LoanContractsController(ILoanContractsAppService loanContractsAppService, IPeopleAppService peopleAppService)
        {
            _loanContractsAppService = loanContractsAppService;
            _peopleAppService = peopleAppService;
        }

        public ActionResult Index()
        {
            var model = new LoanContractsViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_LoanContracts_Create, AppPermissions.Pages_LoanContracts_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(Guid? id)
        {
            GetLoanContractForEditOutput getLoanContractForEditOutput;

            if (id.HasValue)
            {
                getLoanContractForEditOutput = await _loanContractsAppService.GetLoanContractForEdit(new EntityDto<Guid> { Id = (Guid)id });
            }
            else
            {
                getLoanContractForEditOutput = new GetLoanContractForEditOutput
                {
                    LoanContract = new CreateOrEditLoanContractDto()
                };
                getLoanContractForEditOutput.LoanContract.ContractDate = DateTime.Now;
            }

            var viewModel = new CreateOrEditLoanContractModalViewModel()
            {
                LoanContract = getLoanContractForEditOutput.LoanContract,
                PersonList = await _peopleAppService.GetAllPeopleForTableDropdown()
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewLoanContractModal(Guid id)
        {
            var getLoanContractForViewDto = await _loanContractsAppService.GetLoanContractForView(id);

            var model = new LoanContractViewModel()
            {
                LoanContract = getLoanContractForViewDto.LoanContract
            };

            return PartialView("_ViewLoanContractModal", model);
        }

    }
}