using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void IntializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>(); //Service locator

                //Dos not use Migrations, just Create Database with latest changes
                dbContext.Database.EnsureCreated();
                //Applies any pending migrations for the context to the database like (Update-Database)
                dbContext.Database.Migrate();
            }
        }
    }
}
