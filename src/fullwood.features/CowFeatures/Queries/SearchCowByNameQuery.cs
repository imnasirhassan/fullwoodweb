using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Queries
{
    public class SearchCowByNameQuery : IRequest<IEnumerable<Cow>>
    {
        public string SearchTerm { get; set; } = string.Empty;

        public class SearchCowByNameQueryHandler(ICowService<Cow> service)
            : IRequestHandler<SearchCowByNameQuery, IEnumerable<Cow>>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<IEnumerable<Cow>> Handle(SearchCowByNameQuery query, CancellationToken cancellationToken)
            {
                return await _service.Search(query.SearchTerm);
            }
        }
    }
}
