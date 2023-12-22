using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Def.Data;
using SAS.Public.Msg.Scheduler;

var station = new RabbitMQStation();

var newOrder = new EventNewOrder();
DataRandom.Instance.FillPropsRandom(newOrder);
var newOrderBytes = DataConvert.Instance.ToBytes(newOrder);

await station.Connect("Scheduler_App");
while (true)
{
    if (Console.ReadKey().KeyChar == 13)
    {
        break;
    }

    await station.Publish(new Address()
    {
        Channel = "Scheduler_App",
        Exchange = "Scheduler_App_Exchange",
        RoutingKey = "app.scheduler",
    }, new Message()
    {
        Type = "new.order",
        Body = newOrderBytes,
    });
}
