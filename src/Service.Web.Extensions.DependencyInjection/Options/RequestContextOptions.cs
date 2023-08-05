using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Service.Extensions.DependencyInjection.Options;
public record RequestContextOptions {
    [Required]
    public required UserAgentForceOptionInDevelopment UserAgentForceOptionInDevelopment { get; init; }

    public bool CanForceOverrideUserAgent() =>
        DefaultWebEnvironment.WebApps.IsDevelopment() && UserAgentForceOptionInDevelopment.ForceOverride;

    public string? GetUserAgent(HttpContext httpContext) =>
        CanForceOverrideUserAgent()
            ? UserAgentForceOptionInDevelopment.OverrideValue
            : httpContext.Request.Headers.UserAgent;
}

public record UserAgentForceOptionInDevelopment {
    public bool ForceOverride { get; init; }

    [Required]
    public string OverrideValue { get; init; } = null!;
}
