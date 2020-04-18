using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApiOn2._2
{
    public class Program
    {
        public static ILogger Logger;
        public static void Main(string[] args)
        {

            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

          

            host.Run();
            Logger.LogInformation("Seeded the database.");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
