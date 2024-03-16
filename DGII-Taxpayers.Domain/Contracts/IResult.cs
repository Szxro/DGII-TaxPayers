using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IResult
{
    public bool IsSuccess { get; }

    public bool IsFailure { get; }

    public Error Error { get; }

    public Error[]? ValidationErrors { get; }
}
