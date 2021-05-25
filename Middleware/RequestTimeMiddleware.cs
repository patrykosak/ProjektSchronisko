using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Middleware
{
    public static class RequestTimeMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestTimeMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<RequestTimeMiddleware>();
    }
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopWatch;

        public RequestTimeMiddleware()
        {
            _stopWatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMilliseconds = _stopWatch.ElapsedMilliseconds;
            if (elapsedMilliseconds / 1000 > 5)
            {
                await context.Response.WriteAsync("waiting too long, please try later");
            }
        }
    }
}
