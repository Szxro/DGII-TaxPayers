using DGII_Taxpayers.Domain.Entitites.Common;

namespace DGII_Taxpayers.Domain.Entitites;

public class TaxPayer : AuditableEntity
{
    public TaxPayer()
    {
        TaxReceipts = new HashSet<TaxReceipt>();
    }

    public string RncID { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int PersonTypeId { get; set; }

    public PersonType PersonType { get; set; } = new();

    public bool Status { get; set; }

    public ICollection<TaxReceipt> TaxReceipts { get; set; }
}
