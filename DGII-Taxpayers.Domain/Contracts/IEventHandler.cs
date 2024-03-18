using MediatR;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IEvent
{
}
