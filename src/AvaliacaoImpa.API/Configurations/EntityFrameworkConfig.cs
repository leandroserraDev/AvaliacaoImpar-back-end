using AvaliacaoImpar.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoImpa.API.Configurations
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection EntityFrameworkConfiguration(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
