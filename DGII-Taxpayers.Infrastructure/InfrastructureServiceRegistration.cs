using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Options;
using DGII_Taxpayers.Infrastructure.Persistence;
using DGII_Taxpayers.Infrastructure.Persistence.Interceptors;
using DGII_Taxpayers.Infrastructure.Repositories;
using DGII_Taxpayers.Infrastructure.Services;
using DGII_Taxpayers.Infrastructure.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace DGII_Taxpayers.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment)
        {
            services.AddOptions<DatabaseOptions>()
                    .Configure(options => configuration.GetSection(DatabaseOptions.sectionName).Bind(options));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

            services.AddSingleton<AuditableEntititesInterceptor>();

            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                DatabaseOptions databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                options.UseSqlServer(databaseOptions.ConnectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);

                    sqlServerOptionsAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                })
                .AddInterceptors(serviceProvider.GetRequiredService<AuditableEntititesInterceptor>());

                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                    options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                }
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDateService, DateService>();
            services.AddTransient<IAppDbInitializerService, AppDbInitializerService>();
            services.AddTransient<IPersonTypeRepository, PersonTypeRepository>();


            return services;
        }
    }
}
