using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class PersonTypeErrors
{
    public static readonly Error NotUnique = Error.Conflict("PersonType.Conflit",$"The given typename is not unique ");

    public static readonly Error NotFound = Error.NotFound("PersonType.NotFound", $"The given person type name was not found");

    public static readonly Error NonePersonTypes = Error.NotFound("PersonType.NotFound","There are none person types register yet");
}
