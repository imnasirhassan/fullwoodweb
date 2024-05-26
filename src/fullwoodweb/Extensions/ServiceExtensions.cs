using fullwood.domain.Entities;
using fullwood.features.CowFeatures.Commands;
using fullwood.features.CowFeatures.Queries;
using fullwood.repository.CowRepository;
using fullwood.services.AuthService;
using fullwood.services.CowService;

namespace fullwoodweb.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterDepenencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllCowQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCowCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthQuery).Assembly));

            services.AddTransient<ICowService<Cow>, CowService>();
            services.AddTransient(typeof(ICowRepository<>), typeof(CowRepository<>));
            services.AddSingleton<IAuthService, AuthService>();
        }
    }
}
