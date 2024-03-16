using DGII_Taxpayers.Domain.Entitites.Common;

namespace DGII_Taxpayers.Domain.Entitites;

public class TaxReceipt : AuditableEntity
{
    public int TaxPayerId { get; set; }

    public TaxPayer? TaxPayer { get; }

    public string NCF { get; set; } = string.Empty;

    public double Amount { get; set; }

    public double Itbis18 { get; set; }
}
