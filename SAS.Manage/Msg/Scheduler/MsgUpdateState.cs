namespace SAS.Public.Msg.Scheduler
{
    public class MsgUpdateState
    {
        public Guid RelationId { get; set; }
        public int Index { get; set; }
        public string? State { get; set; }
    }
}
