using MeetGroup.Api.Extensions;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Notificacoes;
using MeetGroup.Business.Services;
using MeetGroup.Data.Context;
using MeetGroup.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MeetGroup.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeetGroupDbContext>();
            services.AddScoped<ISalaRepository,SalaRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ISalaService, SalaService>();
            services.AddScoped<IReservaService, ReservaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}