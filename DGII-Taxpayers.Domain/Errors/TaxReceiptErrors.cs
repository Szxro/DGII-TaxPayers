using DGII_Taxpayers.Domain.Core.Primitives;

namespace DGII_Taxpayers.Domain.Errors;

public static class TaxReceiptErrors
{
    public static readonly Error NotUnique = Error.Conflict("NCF.Conflit", "The NCF is already register");

    public static readonly Error NoneTaxReceipts = Error.NotFound("TaxReceipts.NotFound", "There are none existing tax receipts");

    public static readonly Error NotTaxReceiptsFound = Error.NotFound("TaxReceipts.NotFound",$"There are none existing tax receipts for the given rncId");
}
