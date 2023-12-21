namespace SAS.Messages.Mod
{
    public class Message
    {
        public Guid Id { get; set; }
        public IDictionary<string, object> Header { get; set; }
        public byte[] Body { get; set; }
    }
}
