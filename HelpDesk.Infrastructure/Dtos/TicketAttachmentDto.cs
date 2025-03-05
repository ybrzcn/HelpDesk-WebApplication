using HelpDesk.Core.Entities;

namespace HelpDesk.Infrastructure.Dtos
{
    public class TicketAttachmentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
