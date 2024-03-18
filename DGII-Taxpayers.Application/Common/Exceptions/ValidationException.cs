using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("Se han producido uno o mas errores de validacion")
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