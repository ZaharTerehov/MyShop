using MyShop.ApplicationCore.Interfaces;
using MyShop.Infrastructure;

namespace MyShop.Configuration
{
    public static class ConfigureCoreServices
    {
       internal static IServiceCollection AddCoreServices(this IServiceCollection services) 
       {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            
            return services;
       }
    }
}
