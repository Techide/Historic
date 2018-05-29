using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Historic.Api {
    public class Program {
        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) => {
                var env = hostingContext.HostingEnvironment;

                config
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                //if (env.IsDevelopment()) {
                //    var assembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                //    if (assembly != null) {
                //        config.AddUserSecrets(assembly, optional: true);
                //    }
                //}

                config.AddEnvironmentVariables();

                //if (args != null) {
                //    config.AddCommandLine(args);
                //}
            })
                .UseStartup<Startup>()
                .Build();
    }
}
