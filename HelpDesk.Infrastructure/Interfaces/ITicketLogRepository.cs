using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketLogRepository : IBaseRepository<TicketLog, TicketLogDto>
    {
        Task<IEnumerable<TicketLogDto>> GetTicketLogByTicketAsync(Guid id);
        Task<IEnumerable<TicketLogDto>> GetTicketLogByUserAsync(Guid id);
        Task<IEnumerable<TicketLogDto>> GetTicketLogByActionAsync(Enum action);
    }
}
