namespace DGII_Taxpayers.Domain.Contracts;

public interface ICaheService
{
    //Task<T> GetOrCreateAsync<T>(string key,
    //                            Func<CancellationToken, Task<T>> factory,
    //                            TimeSpan? timeSpan = null,
    //                            CancellationToken cancellationToken = default);

    T? GetSync<T>(string key);

    void SetSync<T>(string key,T value,TimeSpan timeSpan);

    void RemoveSync(string key);
}
