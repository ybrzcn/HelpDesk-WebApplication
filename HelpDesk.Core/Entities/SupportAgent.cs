using HelpDesk.Core.Enums;

namespace HelpDesk.Core.Entities;

public class SupportAgent : UserBase
{
    public AgentRole Role { get; set; }
    public List<Ticket> AssignedTickets { get; set; }
    public List<TicketCategory> AllowedCategories { get; set; } = new();
}
