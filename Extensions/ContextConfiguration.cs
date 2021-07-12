using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OwnerAPI.Repositories;

namespace OwnerAPI.Extensions
{
    public static class ContextConfiguration
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(builder => {
                builder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}