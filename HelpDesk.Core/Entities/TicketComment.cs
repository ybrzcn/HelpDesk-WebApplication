namespace HelpDesk.Core.Entities;

public class TicketComment : BaseEntity
{
    public string Content { get; set; }
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }
    public Guid AuthorId { get; set; }
    public UserBase Author { get; set; }
}
