namespace DGII_Taxpayers.Domain.Contracts;

public interface IAppDbInitializerService
{
    Task ConnectAsync();

    Task MigrateAsync();

    Task SeedAsync();
}
