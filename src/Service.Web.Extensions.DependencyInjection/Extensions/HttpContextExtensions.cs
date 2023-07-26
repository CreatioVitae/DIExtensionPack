using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.Extensions.DependencyInjection.Markers;
using System;
using WebPack.CoreLib.HttpHeaders.RequestedDatetimeOverrides;

namespace Service.Web.Extensions.DependencyInjection.Extensions;
public static class HttpContextExtensions {
    public static void OverrideRequestedDatetime<TRequestContext>(this TRequestContext requestContext, HttpContext context) where TRequestContext : IRequestContext {
        if (DefaultWebEnvironment.WebApps.IsDevelopment() && context.GetForceOverrideRequestedDatetimeFromHeader() && context.GetOverrideRequestedDatetimeFromHeader() is { } nonnullRequestedDatetime) {
            var type = requestContext.GetType();
            var prop = type.GetProperty(nameof(requestContext.RequestedDatetime));
            ArgumentNullException.ThrowIfNull(prop);
            prop.SetValue(requestContext, nonnullRequestedDatetime);
        }
    }
}
