using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.poto;
using AvaliacaoImpar.Infra.Repositories;
using AvaliacaoImpar.Infra.Repositories.car;
using AvaliacaoImpar.Infra.Repositories.photo;

namespace AvaliacaoImpa.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IRepositoryCar, RepositoryCar>();
            services.AddScoped<IRepositoryPhoto, RepositoryPhoto>();


            return services;
        }
    }
}
