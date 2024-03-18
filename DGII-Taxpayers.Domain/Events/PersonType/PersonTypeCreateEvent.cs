using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Domain.Events.PersonType;

public record PersonTypeCreateEvent(string typeName) : IEvent { }
