using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DGII_Taxpayers.Infrastructure.Services;

public sealed class AppDbInitializerService : IAppDbInitializerService
{
    private readonly ILogger<AppDbInitializerService> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly IPersonTypeRepository _personTypeRepository;

    public AppDbInitializerService(ILogger<AppDbInitializerService> logger,
                                  AppDbContext appDbContext,
                                  IPersonTypeRepository personTypeRepository)
    {
        _logger = logger;
        _appDbContext = appDbContext;
        _personTypeRepository = personTypeRepository;
    }

    public async Task ConnectAsync()
    {
        try
        {
            await _appDbContext.Database.CanConnectAsync();

        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured trying to connect to the database with the provider name {databaseProviderName} : {message}", _appDbContext.Database.ProviderName, ex.Message);

            throw;
        }
    }

    public async Task MigrateAsync()
    {
        try
        {
            await _appDbContext.Database.MigrateAsync();

        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured trying to do migration to the database with the provider name {databaseProviderName} : {message}", _appDbContext.Database.ProviderName, ex.Message);
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedPersonTypeAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred trying to seed the database with the error message : {message}", ex.Message);

            throw;
        }
    }

    private async Task TrySeedPersonTypeAsync()
    {
        if (!_appDbContext.PersonType.Any())
        {
            await _personTypeRepository.AddDefaultPersonType();
        }
    }
}
