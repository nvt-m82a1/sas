using SAS.Manage.Scheduler.Databases;
using SAS.Manage.Scheduler.Databases.Entities;
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

            var eventNewOrder = DataConvert.Instance.ToClass<EventNewOrder>(message.Body);

            var type = MDatabases.Instance.Ordertypes.FirstOrDefault(record => record.Typename == eventNewOrder.Typename);
            if (type == null)
            {
                var newOrdertype = new Ordertype()
                {
                    Id = Guid.NewGuid(),
                    Typename = eventNewOrder.Typename,
                };
                MDatabases.Instance.Ordertypes.Add(newOrdertype);
                type = newOrdertype;
            }

            var newOrder = new Order()
            {
                Id = eventNewOrder.RelationId,
                TypeId = type.Id,
                Priority = eventNewOrder.Priority,
            };
            MDatabases.Instance.Orders.Add(newOrder);

            var newState = new State()
            {
                Id = eventNewOrder.RelationId,
                ResultCount = eventNewOrder.ResultCount,
            };
            MDatabases.Instance.States.Add(newState);

            var newStatus = new Status()
            {
                Id = eventNewOrder.RelationId,
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
            };
            MDatabases.Instance.Status.Add(newStatus);

            return Task.CompletedTask;
        }
    }
}
