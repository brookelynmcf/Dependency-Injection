namespace DependencyInjection;

public class SpecificDatabase1: IDatabase
{
    public void Persist(string data)
    {
        Console.WriteLine($"SpecificDatabase1 data: {data}");
    }
}