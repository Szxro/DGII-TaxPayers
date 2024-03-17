using DGII_Taxpayers.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DGII_Taxpayers.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TaxPayer> TaxPayer => Set<TaxPayer>();

    public DbSet<TaxReceipt> TaxReceipt => Set<TaxReceipt>();

    public DbSet<PersonType> PersonType => Set<PersonType>();
}
