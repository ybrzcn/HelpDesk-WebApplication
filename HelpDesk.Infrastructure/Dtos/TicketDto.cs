using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;

namespace HelpDesk.Infrastructure.Dtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifideDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
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
    }
}
