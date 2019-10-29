using System;
using System.Threading.Tasks;
using ITI.PrimarySchool.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ITI.PrimarySchool.WebApp.Middlewares
{
    public class WinOrLoseMiddleware
    {
        readonly RequestDelegate _next;

        public WinOrLoseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWinOrLoseService winOrLoseService)
        {
            if (winOrLoseService.WinOrLose())
            {
                await context.Response.WriteAsync("You lose!");
            }
            else
            {
                await context.Response.WriteAsync("You win!");
                await context.Response.WriteAsync(Environment.NewLine);
                await _next(context);
            }
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWinOrLoseMiddleWare(this IApplicationBuilder @this)
        {
            return @this.UseMiddleware<WinOrLoseMiddleware>();
        }
    }
}