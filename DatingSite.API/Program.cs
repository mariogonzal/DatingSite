using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingSite.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingSite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope() )
            {
                var services= scope.ServiceProvider;
                try{
                
                var datacontext=services.GetRequiredService<DataContext>();
                datacontext.Database.Migrate();
                Seed.SeedData(datacontext);
                }catch(Exception ex){
                    var logger=services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex,"error at runing migrations and seed");
                }


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
}
