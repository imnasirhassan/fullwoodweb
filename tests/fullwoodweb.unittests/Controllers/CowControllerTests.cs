using fullwood.features.CowFeatures.Commands;
using fullwood.features.CowFeatures.Queries;
using fullwood.unittests.common;
using fullwoodweb.Controllers;
using fullwoodweb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace fullwoodweb.unittests.Controllers
{
    public class CowControllerTests : TestBase<CowController>
    {
        public CowControllerTests()
        {
            Initialize();
        }

        [Fact]
        public async Task Returns_all_records()
        {
            MockFor<IMediator>()
                .Setup(x => x.Send(It.IsAny<GetAllCowQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(CowData);

            var actionResult = await _sut.Index();

            var result = (actionResult as ViewResult).Model as IEnumerable<CowViewModel>;

            result.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Adds_record_to_db()
        {
            MockFor<IMediator>()
                .Setup(x => x.Send(It.IsAny<AddCowCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actionResult = await _sut.Create(new CowViewModel { 
                CowName = "Bertha",
                CowNumber = 123,
                RegisteredDate = DateTime.Now
            });

            var result = actionResult as RedirectToActionResult;

            result.ActionName.ShouldBe("Index");
        }
    }
}
