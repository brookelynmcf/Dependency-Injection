namespace DependencyInjection;

public class SpecificDatabase2: IDatabase
{
    public void Persist(string data)
    {
        Console.WriteLine($"SpecificDatabase2 data: {data}");
    }
}