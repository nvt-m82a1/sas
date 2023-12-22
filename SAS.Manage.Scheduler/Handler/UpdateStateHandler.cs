using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Msg.Scheduler;

namespace SAS.Manage.Scheduler.Handler
{
    internal class UpdateStateHandler : IMessageHandler
    {
        public Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return Task.CompletedTask;
            }

            var updateState = DataConvert.Instance.ToClass<EventUpdateState>(message.Body);

            return Task.CompletedTask;
        }
    }
}
