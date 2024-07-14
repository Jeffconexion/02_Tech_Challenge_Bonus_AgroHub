using AgroHub.Infrastructure.IoC;

namespace AgroHub.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            NativeDependencyInjector.RegisterServices(services);
        }
    }
}
