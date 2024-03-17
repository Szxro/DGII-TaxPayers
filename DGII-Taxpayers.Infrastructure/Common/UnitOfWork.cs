using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void ChangeContextTrackerToUnchanged(object entity)
    {
        _appDbContext.Entry(entity).State = EntityState.Unchanged;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
