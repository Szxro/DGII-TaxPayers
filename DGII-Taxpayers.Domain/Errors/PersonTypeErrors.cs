using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class PersonTypeErrors
{
    public static readonly Error NotUnique = Error.Conflict("PersonType.Conflit",$"El nombre de tipo de persona dado no es unica");

    public static readonly Error NotFound = Error.NotFound("PersonType.NotFound", $"No se encontro el nombre del tipo de persona indicado");

    public static readonly Error NonePersonTypes = Error.NotFound("PersonType.NotFound", "No hay ningun tipo de persona registrado todavía");
}
