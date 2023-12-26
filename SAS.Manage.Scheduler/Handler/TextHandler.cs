using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert.v2;
using SAS.Public.Msg.Common;

namespace SAS.Manage.Scheduler.Handler
{
    internal class TextHandler : IMessageHandler
    {
        public async Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return;
            }

            var text = DataNullableConvert.Instance.ToClass<EventText>(message.Body);
            Console.WriteLine("Scheduler receive message: " + text?.Message);
        }
    }
}
