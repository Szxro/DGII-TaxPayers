using DGII_Taxpayers.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGII_Taxpayers.Infrastructure.Persistence.Configurations;

public class TaxPayerConfiguration : IEntityTypeConfiguration<TaxPayer>
{
    public void Configure(EntityTypeBuilder<TaxPayer> builder)
    {
        builder.HasIndex(x => x.RncID).IsUnique();
    }
}
