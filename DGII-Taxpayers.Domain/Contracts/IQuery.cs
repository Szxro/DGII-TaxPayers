using MediatR;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IQuery<out TResponse> : IRequest<TResponse> { }

public interface ICachedQuery<out TResponse> : IQuery<TResponse> , ICachedQuery{ }

public interface ICachedQuery
{
    string CahedKey { get; }

    TimeSpan Expiration { get; }
}
