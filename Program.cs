using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using src.Models;

namespace Site
{
public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) {
                DbInitializer.Initialize(scope.ServiceProvider.GetRequiredService<MijnContext>());
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class DbInitializer {
        public static void Initialize(MijnContext context)
        {
            if (context.PS_Lijsts.Any()) return;

            //  context.PS_Lijsts.Add(new PS_Lijst("PS5", "Guardians of the Galaxy", 60.00, 5, "bol.com"));

            context.SaveChanges();
        }
    }
}
