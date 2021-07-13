using Microsoft.Extensions.DependencyInjection;

namespace OwnerAPI.Extensions
{
    public static class MapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}