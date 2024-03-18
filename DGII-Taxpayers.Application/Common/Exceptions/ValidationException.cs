using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new List<Error[]>();
    }
    public IReadOnlyCollection<Error[]> Errors { get; }

    public ValidationException(Error[] validationErrors)
        : this()
    {
        Errors = new List<Error[]>() { validationErrors }; 
    }
}