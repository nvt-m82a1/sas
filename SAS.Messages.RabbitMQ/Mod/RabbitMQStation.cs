using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SAS.Messages.Mod;
using System.Collections.Concurrent;

namespace SAS.Messages.RabbitMQ.Mod
{
    public class RabbitMQStation : Station
    {
        private IConnection connection { get; set; }
        private ConcurrentDictionary<string, IModel> channels { get; set; }
        private ConcurrentDictionary<Guid, string?> consumes { get; set; }

        public RabbitMQStation()
        {
            channels = new ConcurrentDictionary<string, IModel>();
            consumes = new ConcurrentDictionary<Guid, string?>();
        }

        public override Task Connect()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "sas";
            factory.HostName = "localhost";

            factory.AutomaticRecoveryEnabled = true;
            factory.DispatchConsumersAsync = true;

            connection = factory.CreateConnection();
            return Task.CompletedTask;
        }

        public override Task Registry(Address address, Mailbox mailbox)
        {
            if (!channels.ContainsKey(address.Channel))
            {
                IModel newChannel = connection.CreateModel();
                channels[address.Channel] = newChannel;
            }

            var channel = channels[address.Channel];

            if (!string.IsNullOrEmpty(address.Exchange))
            {
                channel.ExchangeDeclare(address.Exchange, address.ExchangeType, true, true);

                if (!string.IsNullOrEmpty(address.Queue))
                {
                    channel.QueueDeclare(address.Queue, true, true, true);
                    channel.QueueBind(address.Queue, address.Exchange, address.RoutingKey);

                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.Received += (model, deliverMsg) =>
                    {
                        var message = new Message()
                        {
                            Body = deliverMsg.Body.ToArray(),
                        };
                        return mailbox.Receive(message);
                    };
                    var consumerId = channel.BasicConsume(address.Queue, true, consumer);
                    consumes.TryAdd(mailbox.Id, consumerId);
                }
            }

            return Task.CompletedTask;
        }

        public override Task Send(Address address, Message message)
        {
            if (channels.TryGetValue(address.Channel, out var channel))
            {
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = 2;
                props.Headers = message.Header;
                channel.BasicPublish(address.Exchange, address.RoutingKey, props, message.Body);
            }

            return Task.CompletedTask;
        }
    }
}
