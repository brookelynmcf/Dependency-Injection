using static System.Guid;

namespace DependencyInjection;

public class DefaultEntity: ITransientEntity, IScopedEntity, ISingletonEntity
{
    // Default entity id to demonstrate the lifetime of a service
    public string EntityId { get; } = NewGuid().ToString()[^5..];
}