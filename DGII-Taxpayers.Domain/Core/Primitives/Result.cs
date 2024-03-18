using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Domain.Core.Primitives;

public readonly struct Result : IResult
{
    public Result(bool isSuccess, Error error, Error[]? validationErrors)
    {
        if (isSuccess && error != Error.None
            || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid Error {error}", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        IsFailure = !isSuccess;
        ValidationErrors = validationErrors;
    }

    public bool IsSuccess { get; }

    public bool IsFailure { get; }

    public Error Error { get; }

    public Error[]? ValidationErrors { get; }

    public static Result Success() => new Result(true, Error.None,null); 

    public static Result Failure(Error error) => new Result(false, error,null);

    public static Result ValidationFailure(Error[] errors) => new Result(false, Error.ValidationError, errors);
}
