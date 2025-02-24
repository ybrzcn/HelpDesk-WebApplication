using HelpDesk.Core.Entities.BaseEntities;

namespace HelpDesk.Core.Entities;

public class TicketCategory : BaseEntity
{
    public string Name { get; set; }
    public List<Ticket> Tickets { get; set; } = new();
    public List<Customer> AllowedCustomers { get; set; } = new();
    public List<SupportAgent> AllowedAgents { get; set; } = new();
}
