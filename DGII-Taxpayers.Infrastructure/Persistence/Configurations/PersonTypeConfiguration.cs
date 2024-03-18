using DGII_Taxpayers.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGII_Taxpayers.Infrastructure.Persistence.Configurations;

public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.HasIndex(x => x.TypeName).IsUnique();
    }
}
