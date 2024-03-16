using MediatR;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
