using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class TaxPayerErrors
{
    public static readonly Error NotUnique = Error.Conflict("RncId.Conflit","El RncCedula ya esta registrado");

    public static readonly Error NoneTaxPayers = Error.NotFound("TaxPayers.NotFound", "No hay contribuyentes existentes");

    public static readonly Error NotFound = Error.NotFound("TaxPayer.NotFound",$"No existen contribuyentes con el RncCedula dado");
}
