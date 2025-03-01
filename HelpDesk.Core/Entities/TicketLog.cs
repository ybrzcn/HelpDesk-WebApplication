using HelpDesk.Core.Entities.BaseEntities;
using HelpDesk.Core.Enums;

namespace HelpDesk.Core.Entities;

public class TicketLog : BaseEntity
{
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }
    public TicketAction Action { get; set; }
    public Guid UserId { get; set; }
    public UserBase User { get; set; }
}