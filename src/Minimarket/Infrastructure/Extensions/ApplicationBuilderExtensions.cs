using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Init database sql server in run time
        /// </summary>
        public static void IntializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>(); //Service locator

                //Dos not use Migrations, just Create Database with latest changes
                 dbContext.Database.EnsureCreatedAsync(default);
                //Applies any pending migrations for the context to the database like (Update-Database)
                dbContext.Database.MigrateAsync(default);
            }
        }

        /// <summary>
        /// Handler every exception that event in app
        /// </summary>
        /// <param name="builder"></param>
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
