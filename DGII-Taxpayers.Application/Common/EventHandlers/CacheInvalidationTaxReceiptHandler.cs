using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Events.TaxReceipt;

namespace DGII_Taxpayers.Application.Common.EventHandlers;

internal class CacheInvalidationTaxReceiptHandler
    : IEventHandler<TaxReceiptCreateEvent>
{
    private readonly ICaheService _caheService;

    public CacheInvalidationTaxReceiptHandler(ICaheService caheService)
    {
        _caheService = caheService;
    }

    public Task Handle(TaxReceiptCreateEvent notification, CancellationToken cancellationToken)
    {
        _caheService.RemoveSync("tax-receipts");

        _caheService.RemoveSync($"tax-receipt-{notification.rncId}");

        return Task.CompletedTask;
    }
}
