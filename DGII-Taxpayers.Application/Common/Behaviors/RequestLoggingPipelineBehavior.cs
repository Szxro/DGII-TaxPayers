using DGII_Taxpayers.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DGII_Taxpayers.Application.Common.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : IResult
{
    private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;

        _logger.LogInformation("Processing the request {requestName}", requestName);

        TResponse response = await next();

        if (response.IsSuccess)
        {
            _logger.LogInformation("Completed the request {requestName}", requestName);

            return response;
        }

        _logger.LogInformation("Completed the request {requestName} with error {errorName}", requestName, response.Error.ErrorCode);

        return response;
    }
}