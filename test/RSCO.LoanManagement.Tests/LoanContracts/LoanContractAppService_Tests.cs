using System;
using System.Linq;
using System.Threading.Tasks;
using RSCO.LoanManagement.LoanContracts.Dtos;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using RSCO.LoanManagement.LoanContracts;
using Shouldly;
using Xunit;
using Abp.Timing;

namespace RSCO.LoanManagement.Tests.LoanContracts
{
    public class LoanContractsAppService_Tests : AppTestBase
    {
        private readonly ILoanContractsAppService _loanContractsAppService;

        private readonly Guid _loanContractTestId;

        public LoanContractsAppService_Tests()
        {
            _loanContractsAppService = Resolve<ILoanContractsAppService>();
            _loanContractTestId = Guid.NewGuid();
        }

        [Fact]
        public async Task Should_Get_All_LoanContracts()
        {
            var loanContracts = await _loanContractsAppService.GetAll(new GetAllLoanContractsInput());

            loanContracts.TotalCount.ShouldBe(1);
            loanContracts.Items.Count.ShouldBe(1);

            loanContracts.Items.Any(x => x.LoanContract.Id == _loanContractTestId).ShouldBe(true);
        }

        [Fact]
        public async Task Should_Get_LoanContract_For_View()
        {
            var loanContract = await _loanContractsAppService.GetLoanContractForView(_loanContractTestId);

            loanContract.ShouldNotBe(null);
        }

        [Fact]
        public async Task Should_Get_LoanContract_For_Edit()
        {
            var loanContract = await _loanContractsAppService.GetLoanContractForEdit(new EntityDto<Guid> { Id = _loanContractTestId });

            loanContract.ShouldNotBe(null);
        }

        [Fact]
        protected virtual async Task Should_Create_LoanContract()
        {
            var loanContract = new CreateOrEditLoanContractDto
            {
                ContractDate = DateTime.Now,
                Amount = 0,
                Summery = "Test value",
                Id = _loanContractTestId
            };

            await _loanContractsAppService.CreateOrEdit(loanContract);

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.LoanContracts.FirstOrDefaultAsync(e => e.Id == _loanContractTestId);
                entity.ShouldNotBe(null);
            });
        }

        [Fact]
        protected virtual async Task Should_Update_LoanContract()
        {
            var loanContract = new CreateOrEditLoanContractDto
            {
                ContractDate = Clock.Now.AddDays(3).Date,
                Amount = 1,
                Summery = "Updated test value",
                Id = _loanContractTestId
            };

            await _loanContractsAppService.CreateOrEdit(loanContract);

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.LoanContracts.FirstOrDefaultAsync(e => e.Id == loanContract.Id);
                entity.ShouldNotBeNull();

                entity.ContractDate.ShouldBe(Clock.Now.AddDays(3).Date);
                entity.Amount.ShouldBe(1);
                entity.Summery.ShouldBe("Updated test value");
            });
        }

        [Fact]
        public async Task Should_Delete_LoanContract()
        {
            await _loanContractsAppService.Delete(new EntityDto<Guid> { Id = _loanContractTestId });

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.LoanContracts.FirstOrDefaultAsync(e => e.Id == _loanContractTestId);
                entity.ShouldBeNull();
            });
        }
    }
}