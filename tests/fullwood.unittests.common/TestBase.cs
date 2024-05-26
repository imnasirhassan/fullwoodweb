using fullwood.domain.Entities;
using Moq;
using Moq.AutoMock;
using Microsoft.EntityFrameworkCore;
using fullwood.infrastructure.Data;

namespace fullwood.unittests.common
{
    public class TestBase<T> where T : class
    {
        protected T? _sut;
        protected AutoMocker? _container;
        protected DbContextOptions<FullwoodDbContext>? _dbContextOptions;
        protected FullwoodDbContext? _context;
        private const string DbName = "FullwoodDb";

        public void Initialize()
        {
            _container = new AutoMocker(MockBehavior.Default);
            _sut = _container.CreateInstance<T>();
        }

        protected Mock<T1> MockFor<T1>() where T1 : class
            => _container.GetMock<T1>();

        protected static IEnumerable<Cow> CowData =>
            [
                new() {
                    Id = 1,
                    CowName = "Paula",
                    CowNumber = 1,
                    OnFarm = true,
                    RegisteredDate = DateTime.Now,
                },
                new() {
                        Id = 2,
                        CowName = "Bertha",
                        CowNumber = 2,
                        OnFarm = true,
                        RegisteredDate = DateTime.Now,
                    }
            ];

        protected void SetDbData()
        {
            _dbContextOptions = new DbContextOptionsBuilder<FullwoodDbContext>()
               .UseInMemoryDatabase(databaseName: DbName)
               .Options;
            _context = new FullwoodDbContext(_dbContextOptions);

            _context.Cows.AddRange(MoqCowData);
            _context.SaveChanges();
        }

        private static IEnumerable<Cow> MoqCowData
        {
            get
            {
                var cowData = new List<Cow>
                {
                    new() {
                    Id = 1,
                    CowName = "Paula",
                    CowNumber = 1,
                    OnFarm = true,
                    RegisteredDate = DateTime.Now,
                },
                new() {
                        Id = 2,
                        CowName = "Bertha",
                        CowNumber = 2,
                        OnFarm = true,
                        RegisteredDate = DateTime.Now,
                    }
                };

                return cowData;
            }
        }
    }
}
