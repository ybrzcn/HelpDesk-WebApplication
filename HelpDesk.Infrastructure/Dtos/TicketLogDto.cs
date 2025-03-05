using HelpDesk.Core.Entities.BaseEntities;
using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;

namespace HelpDesk.Infrastructure.Dtos
{
    public class TicketLogDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public TicketAction Action { get; set; }
        public Guid UserId { get; set; }
        public UserBase User { get; set; }
    }
}
