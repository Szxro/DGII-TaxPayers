using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Options;
using DGII_Taxpayers.Infrastructure.Options.Validations;
using DGII_Taxpayers.Infrastructure.Persistence;
using DGII_Taxpayers.Infrastructure.Persistence.Interceptors;
using DGII_Taxpayers.Infrastructure.Repositories;
using DGII_Taxpayers.Infrastructure.Services;
using DGII_Taxpayers.Infrastructure.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IWebHostEnvironment environment)
        {
            services.AddOptions<DatabaseOptions>()
                    .BindConfiguration(DatabaseOptions.sectionName);

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

            services.AddMemoryCache();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDateService, DateService>();
            services.AddSingleton<ICaheService, CacheService>();
            services.AddScoped<IAppDbInitializerService, AppDbInitializerService>();
            services.AddScoped<IPersonTypeRepository, PersonTypeRepository>();
            services.AddScoped<ITaxPayerRepository, TaxPayerRepository>();
            services.AddScoped<ITaxReceiptRepository, TaxReceiptRepository>();


            return services;
        }

        public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            IAppDbInitializerService initializer = scope.ServiceProvider.GetRequiredService<IAppDbInitializerService>();

            await initializer.ConnectAsync();

            await initializer.MigrateAsync();

            await initializer.SeedAsync();
        }
    }
}
