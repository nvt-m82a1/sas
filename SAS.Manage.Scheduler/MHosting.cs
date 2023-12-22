using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.Manage.Scheduler.Handler;
using SAS.Manage.Scheduler.Mailboxs;
using SAS.Manage.Scheduler.Mod;
using SAS.Messages.Abs;
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
                services.AddSingleton<MScheduler>();
                services.AddSingleton<RabbitMQStation>();

                services.AddKeyedScoped<IMessageHandler, NewOrderHandler>("new.order");
                services.AddKeyedScoped<IMessageHandler, UpdateStateHandler>("update.state");
            });

            var host = builder.Build();

            var connector = host.Services.GetRequiredService<Connector>();
            await connector.Connect();

            await host.RunAsync();
        }
    }
}
