using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class TaxReceiptErrors
{
    public static readonly Error NotUnique = Error.Conflict("NCF.Conflit", "El NCF ya está registrado");

    public static readonly Error NoneTaxReceipts = Error.NotFound("TaxReceipts.NotFound", "No existen recibos fiscales existentes");

    public static readonly Error NotTaxReceiptsFound = Error.NotFound("TaxReceipts.NotFound",$"No existen recibos de impuestos para el RncCedula dado");
}
