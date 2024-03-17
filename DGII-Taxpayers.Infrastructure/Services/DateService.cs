using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Infrastructure.Services;

public class DateService : IDateService
{
    public DateTime NowUTC => DateTime.UtcNow;
}
