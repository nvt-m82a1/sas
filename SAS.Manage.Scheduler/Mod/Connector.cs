using Microsoft.Extensions.DependencyInjection;
using SAS.Manage.Scheduler.Mailboxs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Scheduler.Mod
{
    internal class Connector
    {
        private IServiceProvider services { get; set; }

        public Connector(IServiceProvider services)
        {
            this.services = services;
        }

        public async Task Connect()
        {
            var scheduler = services.GetRequiredService<MScheduler>();
            var station = services.GetRequiredService<RabbitMQStation>();

            await station.Registry(new Address()
            {
                Channel = "Scheduler_App",
                Exchange = "Scheduler_App_Exchange",
                ExchangeType = "direct",
                Queue = "Scheduler_App_Queue",
                RoutingKey = "app.scheduler",
            }, scheduler);
        }
    }
}
