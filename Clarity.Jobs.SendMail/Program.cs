using Clarity.Core.Data;
using Clarity.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clarity.Jobs.SendMail
{
    internal class Program
    {
        public static IConfigurationRoot? Configuration { get; set; }
        private static string SendGridKey = "test";

        static async Task Main(string[] args)
        {
            Configure();
            var provider = ConfigureServices();
            var context = provider.GetService<ApplicationDbContext>();
            var emailService = provider.GetService<IEmailService>();
            
            Console.WriteLine("Starting email send");            

            await emailService.SendPendingNotifications(SendGridKey);

            Console.WriteLine("End");
        }

        private static Microsoft.Extensions.DependencyInjection.ServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddOptions();

            services.AddDbContextPool<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("ClarityDbContext"));
            });

            services.AddTransient<IEmailService, EmailService>();            

            return services.BuildServiceProvider();
        }

        protected static void Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            SendGridKey = Configuration["SendGridApiKey"];
        }
    }
}
