using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShowCaseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //var config = new ConfigurationBuilder()
                    //    .SetBasePath(Directory.GetCurrentDirectory())
                    //    .AddEnvironmentVariables()
                    //    .AddJsonFile("certificate.json", optional: true, reloadOnChange: true)
                    //    .AddJsonFile($"certificate.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                    //    .Build();

                    //var certificateSettings = config.GetSection("certificateSettings");
                    //string certificateFileName = certificateSettings.GetValue<string>("filename");
                    //string certificatePassword = certificateSettings.GetValue<string>("password");

                    //webBuilder.UseStartup<Startup>();
                    //webBuilder.ConfigureKestrel(options =>
                    // {
                    //     var cert = new X509Certificate2(certificateFileName, certificatePassword);
                    //     options.ConfigureHttpsDefaults(o =>
                    //     {
                    //         o.ServerCertificate = cert;
                    //         o.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                    //     });
                    // });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
