namespace HelpDesk.Core.Entities;

public class TicketAttachment : BaseEntity
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}
