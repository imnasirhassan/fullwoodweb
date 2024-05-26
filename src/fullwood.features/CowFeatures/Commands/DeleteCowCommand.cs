using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Commands
{
    public class DeleteCowCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCowCommandHandler(ICowService<Cow> service) : IRequestHandler<DeleteCowCommand, int>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<int> Handle(DeleteCowCommand command, CancellationToken cancellationToken)
            {
                return await _service.Delete(command.Id);
            }
        }
    }
}
