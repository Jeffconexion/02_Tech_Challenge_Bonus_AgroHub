using AgroHub.Application.IServices;
using AgroHub.Application.Services;
using AgroHub.Domain.IRepositories;
using AgroHub.Infrastructure.Data.Context;
using AgroHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AgroHub.Infrastructure.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddTransient<IProductServices, ProductServices>();

            #endregion

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            #region Database
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer("Server=KILLUA;Database=DB_FIAP_ARQUITETO;User ID=sa;Password=nR2B5j9gEy;Trusted_Connection=False;TrustServerCertificate=True;");
            });
            #endregion

        }
    }
}
