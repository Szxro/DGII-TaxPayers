using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Persistence.Interceptors;

public class AuditableEntititesInterceptor : SaveChangesInterceptor
{
    private readonly IDateService _dateService;

    public AuditableEntititesInterceptor(IDateService dateService)
    {
        _dateService = dateService;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateAuditableEntities(DbContext context)
    {
        var entities = context.ChangeTracker.Entries<AuditableEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

        foreach (EntityEntry<AuditableEntity> entry in entities)
        {
            if (entry.State == EntityState.Added)
            {
                SetCurrentPropertyValue(entry, nameof(AuditableEntity.CreatedAt), _dateService.NowUTC);
                SetCurrentPropertyValue(entry, nameof(AuditableEntity.ModifiedAt), _dateService.NowUTC);
            }

            if (entry.State == EntityState.Modified)
            {
                SetCurrentPropertyValue(entry, nameof(AuditableEntity.ModifiedAt), _dateService.NowUTC);
            }
        }
    }

    private void SetCurrentPropertyValue(
        EntityEntry entity,
        string propertyName,
        DateTime dateTime
        ) => entity.Property(propertyName).CurrentValue = dateTime;
}
