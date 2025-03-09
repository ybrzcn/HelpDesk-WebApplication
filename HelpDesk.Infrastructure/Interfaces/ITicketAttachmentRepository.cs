using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketAttachmentRepository : IBaseRepository<TicketAttachment, TicketAttachmentDto>
    {
        Task<IEnumerable<TicketAttachmentDto>> GetTicketAttachmentByTicketAsync(Guid id);
    }
}
