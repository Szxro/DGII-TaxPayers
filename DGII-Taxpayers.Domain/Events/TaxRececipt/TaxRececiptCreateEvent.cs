using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Domain.Events.TaxReceipt;

public record TaxReceiptCreateEvent(string rncId) : IEvent { }
