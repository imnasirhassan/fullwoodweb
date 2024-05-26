using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Queries
{
    public class GetCowByIdQuery : IRequest<Cow>
    {
        public int Id { get; set; }

        public class GetCowByIdQueryHandler(ICowService<Cow> service)
            : IRequestHandler<GetCowByIdQuery, Cow>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<Cow> Handle(GetCowByIdQuery query, CancellationToken cancellationToken)
            {
                return await _service.GetById(query.Id);
            }
        }
    }
}
