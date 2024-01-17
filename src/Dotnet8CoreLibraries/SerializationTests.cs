using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dotnet8CoreLibraries;

public class SerializationTests
{

    [Fact]
    public void Missing_members_can_be_required()
    {
        JsonSerializer.Deserialize<Person>(
            """
            {
                "Firstname": "John",
                "Lastname": "Doe",
                "Age": 42
            }
            """);
    }
}

[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
record Person(string Firstname, string Lastname);
