using HelpDesk.Core.Entities.BaseEntities;
using HelpDesk.Core.Entities;

namespace HelpDesk.Infrastructure.Dtos
{
    public class TicketCommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid AuthorId { get; set; }
        public UserBase Author { get; set; }
    }
}
