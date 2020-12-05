using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTracker.Logic
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddLogic(this IServiceCollection services,
                                                  IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(c => c.UseMySql(ServerVersion.AutoDetect(configuration["sql"])));
            services.AddHttpClient<TotalTrackingService>(c => {
                c.BaseAddress = new Uri(configuration["endpoint"]);
                c.DefaultRequestHeaders.Add("x-functions-key", configuration["functionAuth"]);
            });

            return services;
        }

    }
}
