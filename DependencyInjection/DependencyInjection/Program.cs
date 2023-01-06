using Microsoft.Extensions.DependencyInjection;
using DependencyInjection;
using Microsoft.Extensions.Hosting;

// the host is what encapsulates the apps resources. (global context)
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<ITransientEntity, DefaultEntity>()
            .AddScoped<IScopedEntity, DefaultEntity>()
            .AddSingleton<ISingletonEntity, DefaultEntity>()
            .AddTransient<EntityLogger>()
            // We can use abstraction via the IDatabase interface to allow us some flexibility
            // specific databases can easily be swapped out now without having to update every class using the 
            // specific database type.
            .AddTransient<DatabaseLogger>()
            .AddTransient<IDatabase, SpecificDatabase1>())
            //.AddTransient<IDatabase, SpecificDatabase2>())
    .Build();

DatabaseLogger dbLogger = host.Services.GetRequiredService<DatabaseLogger>();
dbLogger.LogDatabase("Some database data");

ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");

await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    EntityLogger logger = provider.GetRequiredService<EntityLogger>();
    logger.LogEntities($"{scope}-Call 1 .GetRequiredService<EntityLogger>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<EntityLogger>();
    logger.LogEntities($"{scope}-Call 2 .GetRequiredService<EntityLogger>()");

    Console.WriteLine();
    
}