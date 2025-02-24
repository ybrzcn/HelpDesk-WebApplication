namespace HelpDesk.Core.Entities;

public class TicketLog : BaseEntity
{
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }
    public string Action { get; set; }
    public Guid UserId { get; set; }
    public UserBase User { get; set; }
}
