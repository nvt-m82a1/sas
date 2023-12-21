namespace SAS.Messages.Mod
{
    public abstract class Station
    {
        public abstract Task Connect();

        public abstract Task Send(Address address, Message message);

        public abstract Task Registry(Address address, Mailbox mailbox);
    }
}
