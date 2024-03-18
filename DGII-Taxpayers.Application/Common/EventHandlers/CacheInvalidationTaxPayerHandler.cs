using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Events.TaxPayer;

namespace DGII_Taxpayers.Application.Common.EventHandlers;

internal class CacheInvalidationTaxPayerHandler
    : IEventHandler<TaxPayerCreateEvent>
{
    private readonly ICaheService _caheService;

    public CacheInvalidationTaxPayerHandler(ICaheService caheService)
    {
        _caheService = caheService;
    }

    public Task Handle(TaxPayerCreateEvent notification, CancellationToken cancellationToken)
    {
        _caheService.RemoveSync("tax-payers");

        return Task.CompletedTask;
    }
}
