using HelpDesk.Core.Entities.BaseEntities;

namespace HelpDesk.Core.Entities;

public class Customer : UserBase
{
    public List<Ticket> Tickets { get; set; } = new();
    public List<TicketCategory> AllowedCategories { get; set; } = new();
}
