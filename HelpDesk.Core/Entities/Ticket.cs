namespace HelpDesk.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
