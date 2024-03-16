using DGII_Taxpayers.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGII_Taxpayers.Domain.Entitites.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    [NotMapped]
    protected List<IEvent> events = new List<IEvent>();

    public void AddEvent(IEvent @event)
    {
        events.Add(@event);
    }

    public void RemoveEvent(IEvent @event)
    {
        events.Remove(@event);
    }

    public void ClearEvents()
    {
        events.Clear();
    }
}
