using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Extensions.DependencyInjection.Markers;
using Service.Extensions.DependencyInjection.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddRequestContext<TRequestContext>(this IServiceCollection serviceDescriptors, string timezoneId) where TRequestContext : class, IRequestContext, new() =>
        serviceDescriptors.AddScoped(serviceProvider => IRequestContext.CreateRequestContext<TRequestContext>(timezoneId));

    public static OptionsBuilder<StorageMountOptions> AddStorageMountOptions(this IServiceCollection services, IConfiguration configuration) =>
        services.AddOptions<StorageMountOptions>().Bind(configuration.GetSection(nameof(StorageMountOptions))).ValidateDataAnnotations();
}
