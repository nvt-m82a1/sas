using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Msg.Scheduler;

namespace SAS.Manage.Scheduler.Handler
{
    internal class NewOrderHandler : IMessageHandler
    {
        public Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return Task.CompletedTask;
            }

            var newOrder = DataConvert.Instance.ToClass<EventNewOrder>(message.Body);

            return Task.CompletedTask;
        }
    }
}
