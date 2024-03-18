using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class TaxPayerErrors
{
    public static readonly Error NotUnique = Error.Conflict("RncId.Conflit","The RncId is already register");

    public static readonly Error NoneTaxPayers = Error.NotFound("TaxPayers.NotFound", "There are none existing taxpayers");

    public static readonly Error NotFound = Error.NotFound("TaxPayer.NotFound",$"There are none existing tax payer with the given RncId");
}
