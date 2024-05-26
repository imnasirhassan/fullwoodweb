using fullwood.domain.Entities;
using fullwood.repository.CowRepository;
using fullwood.unittests.common;
using Shouldly;

namespace fullwood.respository.unittests.CowRepository
{
    public class CowRepositoryTests : TestBase<CowRepository<Cow>>
    {
        [Fact]
        public async Task Returns_all_records()
        {
            SetDbData();

            var _sut = new CowRepository<Cow>(_context);
            var cowData = await _sut.GetAll();

            Should.Equals(2, cowData.ToList().Count);
        }
    }
}
