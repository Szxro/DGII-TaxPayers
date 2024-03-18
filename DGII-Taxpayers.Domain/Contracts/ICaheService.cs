namespace DGII_Taxpayers.Domain.Contracts;

public interface ICaheService
{
    object? GetSync(string key);

    void SetSync<T>(string key,T value,TimeSpan timeSpan);

    void RemoveSync(string key);
}
