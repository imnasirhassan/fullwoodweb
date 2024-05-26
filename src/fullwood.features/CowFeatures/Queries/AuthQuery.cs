using fullwood.domain.Entities;
using fullwood.services.AuthService;
using MediatR;

namespace fullwood.features.CowFeatures.Queries
{
    public class AuthQuery : IRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;

        public class AuthQueryCommand(IAuthService authService) : IRequestHandler<AuthQuery>
        {
            private readonly IAuthService _authService = authService;

            public async Task Handle(AuthQuery query, CancellationToken cancellationToken)
            {
                await _authService.SignInAsync(new LoginModel
                {
                    UserName = query.UserName,
                    RoleName = query.RoleName,
                });
            }
        }
    }
}
