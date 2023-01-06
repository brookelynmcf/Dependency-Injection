namespace DependencyInjection;

public interface IDatabase
{
    public void Persist(string data);
}