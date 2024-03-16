namespace DGII_Taxpayers.Domain.Entitites.Common;

public abstract  class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
