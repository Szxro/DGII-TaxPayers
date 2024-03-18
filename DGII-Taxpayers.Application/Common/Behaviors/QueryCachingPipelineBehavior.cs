using DGII_Taxpayers.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DGII_Taxpayers.Application.Common.Behaviors;

internal class QueryCachingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    where TResponse : IResult
{
    private readonly ICaheService _caheService;
    private readonly ILogger<QueryCachingPipelineBehavior<TRequest, TResponse>> _logger;

    public QueryCachingPipelineBehavior(ICaheService caheService,
                                        ILogger<QueryCachingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _caheService = caheService;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse? cachedResult = _caheService.GetSync<TResponse>(request.CahedKey);

        string requestName = typeof(TRequest).Name;

        if (cachedResult is not null)
        {
            _logger.LogInformation("Cache hit for the request {requestName}",requestName);

            return cachedResult;
        }

        _logger.LogInformation("Cache miss for the request {requestName}",requestName);

        TResponse response = await next();

        if (response.IsSuccess)
        {
            _caheService.SetSync(request.CahedKey,
                                 response,
                                 request.Expiration);
        }

        return response;
    }
}
