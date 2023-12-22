using SAS.Manage.Scheduler.Databases;
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

            var stateEntity = MDatabases.Instance.States[updateState.RelationId];
            if (stateEntity != null)
            {
                switch (updateState.Index)
                {
                    case 1: stateEntity.Result1 = updateState.State; break;
                    case 2: stateEntity.Result2 = updateState.State; break;
                    case 3: stateEntity.Result3 = updateState.State; break;
                    case 4: stateEntity.Result4 = updateState.State; break;
                    case 5: stateEntity.Result5 = updateState.State; break;
                }

                if (updateState.Index is >= 1 and <= 5)
                {
                    MDatabases.Instance.Status[stateEntity.Id].TimeUpdated = DateTime.Now;
                }
            }

            return Task.CompletedTask;
        }
    }
}
