using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Razor_Pages_Tutorial.Data;

namespace Razor_Pages_Tutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //SAVE Cookbook Item - The below code helps improve early DB design workflow.
            #region Cookbook Item
            //EnsureCreated ensures that the database for the context exists.
            //If it exists, no action is taken. If it does not exist, then the database and all its schema are created.
            //EnsureCreated does not use migrations to create the database. A
            //database that is created with EnsureCreated cannot be later updated using migrations.
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var context = services.GetRequiredService<ApplicationDbContext>();
            //        context.Database.EnsureCreated();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred creating the DB.");
            //    }
            //}
            #endregion

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
