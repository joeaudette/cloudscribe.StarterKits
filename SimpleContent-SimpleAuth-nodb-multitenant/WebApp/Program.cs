using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("hosting.json", optional: true)
                    .Build()
                 )
                 .ConfigureAppConfiguration((builderContext, config) =>
                 {
                     config.AddJsonFile("app-tenants-users.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("app-content-project-settings.json", optional: true, reloadOnChange: true)
                         ;
                 })
                .UseStartup<Startup>()
                .Build();
        
        
    }
}
