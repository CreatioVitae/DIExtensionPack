using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Extensions.DependencyInjection.Markers;
using Service.Web.Extensions.DependencyInjection.Extensions;
using System;
using WebPack.CoreLib.HttpHeaders.RequestedDatetimeOverrides;

// ReSharper disable once CheckNamespace
namespace Service.Extensions.DependencyInjection.Filters;

public sealed class RequestedDatetimeOverrideInDevelopmentFilter<TRequestContext> : ActionFilterAttribute where TRequestContext : IRequestContext {
    private TRequestContext RequestContext { get; set; }

    public RequestedDatetimeOverrideInDevelopmentFilter(TRequestContext requestContext) =>
        RequestContext = requestContext;

    public override void OnActionExecuting(ActionExecutingContext context) {
        RequestContext.OverrideRequestedDatetime(context.HttpContext);

        base.OnActionExecuting(context);
    }

   
}
