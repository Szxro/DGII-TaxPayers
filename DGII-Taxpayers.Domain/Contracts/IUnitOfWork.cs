namespace DGII_Taxpayers.Domain.Contracts;

public interface IUnitOfWork
{
    void ChangeContextTrackerToUnchanged(object entity);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
