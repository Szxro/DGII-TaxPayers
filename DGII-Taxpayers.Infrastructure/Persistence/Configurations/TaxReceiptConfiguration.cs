using DGII_Taxpayers.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGII_Taxpayers.Infrastructure.Persistence.Configurations;

public class TaxReceiptConfiguration : IEntityTypeConfiguration<TaxReceipt>
{
    public void Configure(EntityTypeBuilder<TaxReceipt> builder)
    {
        builder.HasIndex(x => x.NCF).IsUnique();
    }
}
