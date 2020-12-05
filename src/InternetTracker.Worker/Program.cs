using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetTracker.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InternetTracker.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogic(hostContext.Configuration);
                    services.AddHostedService<Worker>();
                });
    }
}
