namespace Fishing.Core.Database;

public interface IAuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}