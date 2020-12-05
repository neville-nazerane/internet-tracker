using InternetTracker.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace InternetTracker.WebApp
{
    public static class EndpointExtensions
    {

        public static IEndpointConventionBuilder MapAllEndpoints(this IEndpointRouteBuilder endpoints)
            => new MultiEndpointBuilder { 
            
                endpoints.MapGet("/logs", async context 
                    => await context.Response.WriteAsJsonAsync(
                                await context.GetTotalService().GetLogsAsync(
                                                            context.GetQueryAsDate("start"),
                                                            context.GetQueryAsDate("end"),
                                                            context.RequestAborted)))
            
            };

        private static TotalTrackingService GetTotalService(this HttpContext context)
            => context.RequestServices.GetService<TotalTrackingService>();

        private static DateTime GetQueryAsDate(this HttpContext context, string key)
            => DateTime.Parse(context.Request.Query[key]);

    }
}
