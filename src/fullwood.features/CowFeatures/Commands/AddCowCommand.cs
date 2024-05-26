using fullwood.domain.Entities;
using fullwood.services.CowService;
using MediatR;

namespace fullwood.features.CowFeatures.Commands
{
    public class AddCowCommand : IRequest<int>
    {
        public bool OnFarm { get; set; }
        public int CowNumber { get; set; }
        public string CowName { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }

        public class AddCowCommandHandler(ICowService<Cow> service) : IRequestHandler<AddCowCommand, int>
        {
            private readonly ICowService<Cow> _service = service;

            public async Task<int> Handle(AddCowCommand command, CancellationToken cancellationToken)
            {
                var cow = new Cow
                {
                    OnFarm = command.OnFarm,
                    CowNumber = command.CowNumber,
                    CowName = command.CowName,
                    RegisteredDate = command.RegisteredDate,
                };

                return await _service.Add(cow);
            }
        }
    }
}
