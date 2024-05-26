using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Commands
{
    public class UpdateCowCommand : IRequest<int>
    {
        public int Id { get; set; }
        public bool OnFarm { get; set; }
        public string CowName { get; set; } = string.Empty;
        public int CowNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        public class UpdateCowCommandHandler(ICowService<Cow> service) : IRequestHandler<UpdateCowCommand, int>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<int> Handle(UpdateCowCommand command, CancellationToken cancellationToken)
            {
                var cow = new Cow
                {
                    Id = command.Id,
                    OnFarm = command.OnFarm,
                    CowName = command.CowName,
                    CowNumber = command.CowNumber,
                    RegisteredDate = command.RegisteredDate,
                };

                return await _service.Update(cow);
            }
        }
    }
}
