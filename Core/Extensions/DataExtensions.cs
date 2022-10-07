using Core.Context;
using Core.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class DataExtensions
    {
        public static void AddRepositores(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddTransient<IUnitOfCRM, UnitOfCRM>();
        }
    }
}
