using DGII_Taxpayers.Domain.Entitites.Common;

namespace DGII_Taxpayers.Domain.Entitites;

public class PersonType : AuditableEntity
{
    public PersonType()
    {
        TaxPayers = new HashSet<TaxPayer>();    
    }

    public string TypeName { get; set; } = string.Empty;

    public ICollection<TaxPayer> TaxPayers { get; set; }
}
