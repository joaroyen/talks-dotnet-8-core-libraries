using System.Diagnostics.Metrics;

namespace Dotnet8CoreLibraries;

public class MetricsTests
{
    [Fact]
    public void Metrics_can_be_created_with_tags_and_cached_by_factory()
    {
        var serviceProvider = new ServiceCollection().AddMetrics().BuildServiceProvider();
        var meterFactory = serviceProvider.GetRequiredService<IMeterFactory>();

        var meter = meterFactory.Create("JobExecutions");

        var jobOneCounter = meter.CreateCounter<int>(
            "JobOne", 
            "execution", 
            "Measure throughput of job executions", 
            new Dictionary<string, object?>
            {
                ["location"] = "Trondheim"
            });
        
        jobOneCounter.Add(1);
    }
}