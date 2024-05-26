using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Queries
{
    public class GetAllCowQuery : IRequest<IEnumerable<Cow>>
    {
        public class GetAllCowQueryHandler(ICowService<Cow> service)
            : IRequestHandler<GetAllCowQuery, IEnumerable<Cow>>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<IEnumerable<Cow>> Handle(GetAllCowQuery query, CancellationToken cancellationToken)
            {
                return await _service.GetAll();
            }
        }
    }
}
