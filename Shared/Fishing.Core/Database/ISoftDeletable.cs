namespace Fishing.Core.Database;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
}