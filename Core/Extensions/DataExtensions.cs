using Core.Context;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("comCRM"));
            });
            return services;
        }

        public static IServiceCollection AddRepositores(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfCRM, UnitOfCRM>();

            return services;
        }
    }
}
