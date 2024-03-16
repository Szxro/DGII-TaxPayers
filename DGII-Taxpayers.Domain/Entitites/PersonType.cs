using DGII_Taxpayers.Domain.Entitites.Common;

namespace DGII_Taxpayers.Domain.Entitites;

public class PersonType : AuditableEntity
{
    public string TypeName { get; set; } = string.Empty;

    public TaxPayer? TaxPayer { get; set; }
}
