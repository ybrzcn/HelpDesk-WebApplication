using HelpDesk.Core.Entities.BaseEntities;
using HelpDesk.Core.Enums;

namespace HelpDesk.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid? AssignedToAgentId { get; set; }
        public SupportAgent? AssignedToAgent { get; set; }
        public Guid CategoryId { get; set; }
        public TicketCategory Category { get; set; }
        public List<TicketComment> Comments { get; set; } = new();
        public List<TicketAttachment> Attachments { get; set; } = new();
    }
}
