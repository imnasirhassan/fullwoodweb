using fullwood.domain.Entities;
using fullwood.repository.CowRepository;
using fullwood.unittests.common;
using Shouldly;

namespace fullwood.services.unittests.CowServiceTests
{
    public class CowServiceTests : TestBase<CowService.CowService>
    {
        public CowServiceTests() { 
            Initialize();
        }

        [Fact]
        public async Task Returns_empty_enumeration_when_no_records_found()
        {
            var list = new List<Cow>();
            MockFor<ICowRepository<Cow>>().Setup(x => x.GetAll())
                .Returns(Task.FromResult(list.AsEnumerable()));

            var data = await _sut.GetAll();

            data.ShouldNotBeNull();
        }

        [Fact]
        public async Task Returns_all_records()
        {
            MockFor<ICowRepository<Cow>>().Setup(x => x.GetAll())
                .Returns(Task.FromResult(CowData));

            var data = await _sut.GetAll();

            data.ShouldNotBeNull();
            Should.Equals(1, data.Count());
        }
    }
}
