using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.Manage.Supervisor.Mailboxs;
using SAS.Manage.Supervisor.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Scheduler
{
    internal class MHosting
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Connector>();
                services.AddSingleton<MManage>();
                services.AddSingleton<RabbitMQStation>();

            });

            var host = builder.Build();

            var connector = host.Services.GetRequiredService<Connector>();
            await connector.Connect();

            await host.RunAsync();
        }
    }
}
