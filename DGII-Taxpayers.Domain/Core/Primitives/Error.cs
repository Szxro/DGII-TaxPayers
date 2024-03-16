namespace DGII_Taxpayers.Domain.Core.Primitives;

public sealed class Error 
{
    private Error(string errorCode,string errorDescription,ErrorType errorType)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ErrorType = errorType;
    }

    public string ErrorCode { get; }

    public string ErrorDescription { get; }

    public ErrorType ErrorType { get; set; }

    public static readonly Error None = new(string.Empty,string.Empty,ErrorType.None);

    public static readonly Error ValidationError = new Error("Validation.Error", "One or more validation failures have occurred", ErrorType.Validation);

    public static Error Validation(string errorCode, string errorDescription) => new(errorCode, errorDescription, ErrorType.Validation);

    public static Error NotFound(string errorCode, string errorDescription) => new(errorCode, errorDescription, ErrorType.NotFound);

    public static Error Conflict(string errorCode, string errorDescription) => new(errorCode, errorDescription, ErrorType.Conflit);
}

public enum ErrorType
{
    None = 0,
    Validation = 1,
    NotFound = 2,
    Conflit = 3
}
