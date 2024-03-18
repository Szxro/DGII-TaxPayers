using DGII_Taxpayers.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGII_Taxpayers.Domain.Entitites.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    [NotMapped]
    public List<IEvent> DomainEvents = new List<IEvent>();

    public void AddEvent(IEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void RemoveEvent(IEvent domainEvent)
    {
        DomainEvents.Remove(domainEvent);
    }

    public void ClearEvents()
    {
        DomainEvents.Clear();
    }
}
