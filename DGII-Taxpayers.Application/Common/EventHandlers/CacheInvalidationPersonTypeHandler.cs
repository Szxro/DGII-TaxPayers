using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Events.PersonType;

namespace DGII_Taxpayers.Application.Common.EventHandlers;

internal class CacheInvalidationPersonTypeHandler
    : IEventHandler<PersonTypeCreateEvent>
{
    private readonly ICaheService _caheService;

    public CacheInvalidationPersonTypeHandler(ICaheService caheService)
    {
        _caheService = caheService;
    }

    public Task Handle(PersonTypeCreateEvent notification, CancellationToken cancellationToken)
    {
        _caheService.RemoveSync("person-types");

        return Task.CompletedTask;
    }
}
