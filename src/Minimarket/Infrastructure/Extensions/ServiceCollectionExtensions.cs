using Entities.Model;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension for Add Identity
        /// </summary>
        /// <param name="services"></param>
        public static void AddAppIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
        }

        /// <summary>
        /// Extension for Add DbContext
        /// </summary>
        /// <param name="services">IServiceCollection </param>
        /// <param name="connectionString">connection string of dbcontext</param>
        public static void AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                // log every thing that related to database
                options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
            });
        }

        /// <summary>
        /// Extension for Add Repository
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepository(this IServiceCollection services)
        {
            // Add Repository With Scoped 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        }
    }
}
