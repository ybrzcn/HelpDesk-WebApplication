using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketLogRepository : IBaseRepository<TicketLog, TicketLogDto>
    {
        Task<IEnumerable<TicketLogDto>> GetTicketLogByTicketAsync(Guid id);
        Task<IEnumerable<TicketLogDto>> GetTicketLogByUserAsync(Guid id);
        Task<IEnumerable<TicketLogDto>> GetTicketLogByActionAsync(TicketAction action);
    }
}
