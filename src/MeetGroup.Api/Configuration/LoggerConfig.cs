﻿using System;
using MeetGroup.Api.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthChecks.NpgSql;
using Npgsql;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MeetGroup.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                o.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                    options.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
                    options.HeartbeatId = "API - Meet Group";

                })
                .AddCheck("Verificar conexão", () =>
                {

                    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        try
                        {
                            connection.Open();
                        }
                        catch (NpgsqlException)
                        {
                            return HealthCheckResult.Unhealthy();
                        }
                    }

                    return HealthCheckResult.Healthy();

                })
                .AddNpgSql(configuration.GetConnectionString("DefaultConnection"));


            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}