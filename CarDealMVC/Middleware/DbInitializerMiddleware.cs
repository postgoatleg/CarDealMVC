using CarDealMVC.Models;
using System.Diagnostics;

namespace CarDealMVC.Middleware
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public DbInitializerMiddleware(RequestDelegate next) => _next = next;
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, CarDealerContext dbContext)
        {
            try
            {
                DbInitializer.Initialize(dbContext);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            /*if (!(context.Session.Keys.Contains("starting")))
            {
                DbInitializer.Initialize(dbContext);
                context.Session.SetString("starting", "Yes");
            }*/

            // Call the next delegate/middleware in the pipeline
            return _next.Invoke(context);
        }
    }
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }

    }
}
