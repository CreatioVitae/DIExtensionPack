using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Extensions.DependencyInjection.Markers;
using System;
using WebPack.CoreLib.HttpHeaders.RequestedDatetimeOverrides;

// ReSharper disable once CheckNamespace
namespace Service.Extensions.DependencyInjection.Filters;

public sealed class RequestedDatetimeOverrideInDevelopmentFilter<TRequestContext> : ActionFilterAttribute where TRequestContext : IRequestContext {
    private TRequestContext RequestContext { get; set; }

    public RequestedDatetimeOverrideInDevelopmentFilter(TRequestContext requestContext) =>
        RequestContext = requestContext;

    public override void OnActionExecuting(ActionExecutingContext context) {
        if (DefaultWebEnvironment.WebApps.IsDevelopment() && context.HttpContext.GetForceOverrideRequestedDatetimeFromHeader() && context.HttpContext.GetOverrideRequestedDatetimeFromHeader() is { } nonnullRequestedDatetime) {
            var type = RequestContext.GetType();
            var prop = type.GetProperty(nameof(RequestContext.RequestedDatetime));
            ArgumentNullException.ThrowIfNull(prop);
            prop.SetValue(RequestContext, nonnullRequestedDatetime);
        }

        base.OnActionExecuting(context);
    }
}
