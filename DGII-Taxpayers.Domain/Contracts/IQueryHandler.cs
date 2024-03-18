using MediatR;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{
}
