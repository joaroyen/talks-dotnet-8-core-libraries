using System.Diagnostics;

namespace Dotnet8CoreLibraries;

public class BackwardCompatibilityTests(ITestOutputHelper testOutput)
{
    [Fact]
    public void Product_version_contain_git_commit()
    {
        var fileVersionInfo = FileVersionInfo.GetVersionInfo(
            typeof(BackwardCompatibilityTests).Assembly.Location);
        
        testOutput.WriteLine($"ProductVersion = {fileVersionInfo.ProductVersion}");
    }
}