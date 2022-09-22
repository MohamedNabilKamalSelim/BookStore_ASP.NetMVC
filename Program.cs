using Bookstore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            //To prebare the migrations to run on external dbserver to publish the project
            //RunMigration(webHost);

            webHost.Run();
        }

        //private static void RunMigration(IHost webHost)
        //{
        //    using(var scope = webHost.Services.CreateScope())
        //    {
        //        var db = scope.ServiceProvider.GetRequiredService<BookstoreDBContext>();
        //        db.Database.Migrate();
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
