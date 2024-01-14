namespace Dotnet8CoreLibraries;

public class DependencyInjectionTests(ITestOutputHelper output)
{
    [Fact]
    public void Multiple_instances_of_same_implementation_are_possible()
    {
        var services = new ServiceCollection();
        services.AddSingleton(output);
        services.AddKeyedSingleton<PriceProvider>("TenantOne");
        services.AddKeyedSingleton<PriceProvider>("TenantTwo");
        services.AddScoped<PriceCalculator>();
        
        var serviceProvider = services.BuildServiceProvider();
        var priceCalculator = serviceProvider.GetRequiredService<PriceCalculator>();
        priceCalculator.Import("TenantOne");
        priceCalculator.Import("TenantTwo");
    }
}

public class PriceCalculator(ITestOutputHelper output, IServiceProvider serviceProvider)
{
    public void Import(string tenant)
    {
        var handler = serviceProvider.GetRequiredKeyedService<PriceProvider>(tenant);
        
        output.WriteLine($"Hash of {tenant} is {handler.GetHashCode()}");
    }
}

public class PriceProvider;

