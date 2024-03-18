using DGII_Taxpayers.Domain.Contracts;

namespace DGII_Taxpayers.Domain.Core.Primitives;

public readonly struct Result<TData>
    : IResult
    where TData : class
{
    public Result(TData? data,bool isSucess,Error error, Error[]? validationErrors)
    {
        if (!isSucess && error == Error.None
            || isSucess && error != Error.None)
        {
            throw new ArgumentException("Invalid Error {error}",nameof(error));
        }

        Data = data;
        IsSuccess = isSucess;
        Error = error;
        ValidationErrors = validationErrors;
        IsFailure = !isSucess;
    }

    public  TData? Data { get; }

    public bool IsSuccess { get; }

    public bool IsFailure { get; }

    public Error Error { get; }

    public Error[]? ValidationErrors { get; }

    public static Result<TData> Success(TData data) => new(data,true,Error.None,null);

    public static Result<TData> Failure(Error error) => new(default,false,error,null);

    public static Result<TData> ValidationFailure(Error[] errors) => new(default,false,Error.ValidationError,errors); 
}
