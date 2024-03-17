namespace DGII_Taxpayers.Infrastructure.Options;

public class DatabaseOptions
{
    public const string sectionName = "DatabaseOptions";

    public string? ConnectionString { get; init; }

    public int MaxRetryCount { get; init; }

    public int CommandTimeout { get; init; }

    public bool EnableDetailedErrors { get; init; }

    public bool EnableSensitiveDataLogging { get; init; }
}
