using DGII_Taxpayers.Domain.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace DGII_Taxpayers.Infrastructure.Services;

public class CacheService : ICaheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public object? GetSync(string key)
    {
        var result = _memoryCache.TryGetValue(key,out object? value);

        if (!result)
        {
            return default;
        }

        return value;
    }

    public void RemoveSync(string key)
    {
        bool result = _memoryCache.TryGetValue(key, out _);

        if (!result)
        {
            return;
        }

        _memoryCache.Remove(key);
    }

    public void SetSync<T>(string key,T value, TimeSpan timeSpan)
    {
        _memoryCache.Set(key, value, timeSpan);
    }
}
