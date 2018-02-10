using Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            // Block main thread until seed data is complete
            MainAsync(host).GetAwaiter().GetResult();

            host.Run();
        }

        static async Task MainAsync(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<DataContext>();
                var configuration = services.GetService<IConfiguration>();

                if (configuration.GetValue<bool>("UseInMemory"))
                    await SeedDataContext.Initialize(services, context, configuration);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(new string[] { "http://localhost:5002" })
                .Build();
    }
}
