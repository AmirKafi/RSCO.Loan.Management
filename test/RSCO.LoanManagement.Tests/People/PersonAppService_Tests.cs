using System;
using System.Linq;
using System.Threading.Tasks;
using RSCO.LoanManagement.People.Dtos;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using RSCO.LoanManagement.People;
using Shouldly;
using Xunit;
using Abp.Timing;

namespace RSCO.LoanManagement.Tests.People
{
    public class PeopleAppService_Tests : AppTestBase
    {
        private readonly IPeopleAppService _peopleAppService;

        private readonly Guid _personTestId;

        public PeopleAppService_Tests()
        {
            _peopleAppService = Resolve<IPeopleAppService>();
            _personTestId = Guid.NewGuid();
            SeedTestData();
        }

        private void SeedTestData()
        {
            var currentTenant = GetCurrentTenant();

            var person = new Person
            {
                FirstName = "Test value",
                LastName = "Test value",
                Id = _personTestId
            };

            UsingDbContext(context =>
            {
                context.People.Add(person);
            });
        }

        [Fact]
        public async Task Should_Get_All_People()
        {
            var people = await _peopleAppService.GetAll(new GetAllPeopleInput());

            people.TotalCount.ShouldBe(1);
            people.Items.Count.ShouldBe(1);

            people.Items.Any(x => x.Person.Id == _personTestId).ShouldBe(true);
        }

        [Fact]
        public async Task Should_Get_Person_For_View()
        {
            var person = await _peopleAppService.GetPersonForView(_personTestId);

            person.ShouldNotBe(null);
        }

        [Fact]
        public async Task Should_Get_Person_For_Edit()
        {
            var person = await _peopleAppService.GetPersonForEdit(new EntityDto<Guid> { Id = _personTestId });

            person.ShouldNotBe(null);
        }

        [Fact]
        protected virtual async Task Should_Create_Person()
        {
            var person = new CreateOrEditPersonDto
            {
                FirstName = "Test value",
                LastName = "Test value",
                Id = _personTestId
            };

            await _peopleAppService.CreateOrEdit(person);

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.People.FirstOrDefaultAsync(e => e.Id == _personTestId);
                entity.ShouldNotBe(null);
            });
        }

        [Fact]
        protected virtual async Task Should_Update_Person()
        {
            var person = new CreateOrEditPersonDto
            {
                FirstName = "Updated test value",
                LastName = "Updated test value",
                Id = _personTestId
            };

            await _peopleAppService.CreateOrEdit(person);

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.People.FirstOrDefaultAsync(e => e.Id == person.Id);
                entity.ShouldNotBeNull();

                entity.FirstName.ShouldBe("Updated test value");
                entity.LastName.ShouldBe("Updated test value");
            });
        }

        [Fact]
        public async Task Should_Delete_Person()
        {
            await _peopleAppService.Delete(new EntityDto<Guid> { Id = _personTestId });

            await UsingDbContextAsync(async context =>
            {
                var entity = await context.People.FirstOrDefaultAsync(e => e.Id == _personTestId);
                entity.ShouldBeNull();
            });
        }
    }
}