namespace DependencyInjection;

public class EntityLogger
{
    private readonly ITransientEntity _transientEntity;
    private readonly ISingletonEntity _singletonEntity;
    private readonly IScopedEntity _scopedEntity;
    private readonly IDatabase _database;

    public EntityLogger(ITransientEntity transientEntity, ISingletonEntity singletonEntity, IScopedEntity scopedEntity, IDatabase database)
    {
        _scopedEntity = scopedEntity;
        _transientEntity = transientEntity;
        _singletonEntity = singletonEntity;
        _database = database;
    }

    public void LogEntities(string scope)
    {
        LogEntity(_transientEntity, scope, "This is always different");
        LogEntity(_singletonEntity, scope, "This is always the same");
        LogEntity(_scopedEntity, scope, "This is only the same within scope");
    }

    private static void LogEntity<T>(T entity, string scope, string message)
        where T : IEntity => Console.WriteLine($"{scope}: {typeof(T).Name,-19} [ {entity.EntityId}...{message,-23} ]");

}