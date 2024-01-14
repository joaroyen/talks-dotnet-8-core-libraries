using Microsoft.Extensions.Time.Testing;

namespace Dotnet8CoreLibraries;

public class TimeProviderTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Time_can_be_controlled_explicitly()
    {
        var timeProvider = new FakeTimeProvider(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));

        var album = new Album(timeProvider, "The Dark Side of the Moon", new DateOnly(1973, 3, 1));

        testOutputHelper.WriteLine($"{album.Title} is {album.Age} years old");
    }
    
    record Album(TimeProvider TimeProvider, string Title, DateOnly ReleaseDate)
    {
        public int Age => 
            (int)(TimeProvider.GetUtcNow() - ReleaseDate.ToDateTime(TimeOnly.MinValue))
            .TotalDays / 365;
    }
}

