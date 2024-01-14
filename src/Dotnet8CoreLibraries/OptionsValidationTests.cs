using System.ComponentModel.DataAnnotations;

namespace Dotnet8CoreLibraries;

public class OptionsValidationTests
{
    [Fact]
    public void Validation_source_is_generated_to_improve_performance()
    {
        var services = new ServiceCollection();
        services.Configure<TenantOptions>(options => options.Id = "12345");
        services.AddSingleton<IValidateOptions<TenantOptions>, TenantValidator>();
    }
}

public class TenantOptions
{
    [Required, MinLength(5, ErrorMessage = "Value for {0} must be at least {1} characters long.")]
    public required string Id { get; set; }
}
    
[OptionsValidator]
partial class TenantValidator : IValidateOptions<TenantOptions>;