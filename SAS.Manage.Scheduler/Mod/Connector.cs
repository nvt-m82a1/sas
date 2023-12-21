using SAS.Manage.Scheduler.Mailboxs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Scheduler.Mod
{
    internal class Connector
    {
        private Station Station { get; set; }

        public Connector()
        {
            Station = new RabbitMQStation();
            Station.Connect();

            Station.Registry(new Address()
            {
                Channel = "Scheduler_App",
                Exchange = "Scheduler_App_Exchange",
                ExchangeType = "direct",
                Queue = "Scheduler_App_Queue",
                RoutingKey = "app.scheduler",
            }, new MBOrder());

            Station.Registry(new Address()
            {
                Channel = "Scheduler_App",
                Exchange = "Scheduler_App_Exchange",
                ExchangeType = "direct",
                Queue = "Scheduler_App_Queue",
                RoutingKey = "app.scheduler",
            }, new MBState());
        }
    }
}
