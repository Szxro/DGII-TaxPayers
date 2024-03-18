using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Domain.Events.TaxPayer;

public record TaxPayerCreateEvent(string RncId) : IEvent { }
