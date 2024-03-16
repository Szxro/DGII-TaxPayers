using MediatR;

namespace DGII_Taxpayers.Domain.Contracts;

public interface ICommand : IRequest { }

public interface ICommand<out TResponse> : IRequest<TResponse> { }
