using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Entitites.Common;
using DGII_Taxpayers.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IPublisher _publisher;

    public UnitOfWork(
        AppDbContext appDbContext,
        IPublisher publisher)
    {
        _appDbContext = appDbContext;
        _publisher = publisher;
    }

    public void ChangeContextTrackerToUnchanged(object entity)
    {
        _appDbContext.Entry(entity).State = EntityState.Unchanged;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<IEvent> events = _appDbContext.ChangeTracker.Entries<BaseEntity>()
                                    .Select(e => e.Entity)
                                    .Where(e => e.DomainEvents.Any())
                                    .SelectMany(e => e.DomainEvents)
                                    .ToArray();

        var result = await _appDbContext.SaveChangesAsync(cancellationToken);

        foreach (IEvent domainEvent in events)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}
