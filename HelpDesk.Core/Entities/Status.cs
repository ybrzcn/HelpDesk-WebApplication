namespace HelpDesk.Core.Entities;

public class Status : BaseEntity
{
    public string Name { get; set; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}
