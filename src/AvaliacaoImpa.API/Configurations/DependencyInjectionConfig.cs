using AvaliacaoImpar.Application.ApplicationServices.card;
using AvaliacaoImpar.Application.Interfaces.Services.Card;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Entities.photo;
using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.photo;
using AvaliacaoImpar.Domain.Interfaces.Services.Base;
using AvaliacaoImpar.Domain.Interfaces.Services.card;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Domain.Interfaces.Services.photo;
using AvaliacaoImpar.Domain.Validators.card;
using AvaliacaoImpar.Domain.Validators.photo;
using AvaliacaoImpar.Infra.Repositories;
using AvaliacaoImpar.Infra.Repositories.car;
using AvaliacaoImpar.Infra.Repositories.photo;
using AvaliacaoImpar.Services.Services.Base;
using AvaliacaoImpar.Services.Services.card;
using AvaliacaoImpar.Services.Services.Notification;
using AvaliacaoImpar.Services.Services.photo;
using FluentValidation;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;

namespace AvaliacaoImpa.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IRepositoryCard, RepositoryCard>();
            services.AddScoped<IRepositoryPhoto, RepositoryPhoto>();


            //Services
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IServiceCard, ServiceCard>();
            services.AddScoped<IServicePhoto, ServicePhoto>();

            //Notification Services
            services.AddScoped<INotificationError, NotificationError>();


            //Application Services
            services.AddScoped<IApplicationServiceCard, ApplicationServiceCard>();


            services.AddScoped<IValidator<Card>, CardValidator>();
            services.AddScoped<IValidator<Photo>, PhotoValidator>();




            return services;
        }
    }
}
