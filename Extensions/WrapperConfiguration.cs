using Microsoft.Extensions.DependencyInjection;
using OwnerAPI.Contracts;
using OwnerAPI.Repositories;

namespace OwnerAPI.Extensions
{
    public static class WrapperConfiguration
    {
        public static void ConfigureWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}