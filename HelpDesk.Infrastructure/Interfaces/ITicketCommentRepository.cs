using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketCommentRepository : IBaseRepository<TicketComment, TicketCommentDto>
    {
        Task<IEnumerable<TicketCommentDto>> GetTicketCommentByTicketAsync(Guid id);
        Task<IEnumerable<TicketCommentDto>> GetTicketCommentByAuthorAsync(Guid id);
    }
}
