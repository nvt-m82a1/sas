using SAS.Messages.Mod;
using SAS.Public.Msg.Scheduler;

namespace SAS.Manage.Scheduler.Mailboxs
{
    internal class MBOrder : Mailbox
    {
        public override Task Receive(Message message)
        {
            var order = new MsgNew();
            //order.FromBytes(message.Body);
            return Task.FromResult(order);
        }
    }
}
