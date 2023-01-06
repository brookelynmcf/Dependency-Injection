namespace DependencyInjection;

public class DatabaseLogger
{
    private readonly IDatabase _database;

    public DatabaseLogger(IDatabase database)
    {
        _database = database;
    }
    
    public void LogDatabase(string data)
    {
        _database.Persist(data);
    }
    

}