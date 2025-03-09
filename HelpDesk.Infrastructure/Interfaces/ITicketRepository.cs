using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket, TicketDto>
    {
        Task<IEnumerable<TicketDto>> GetTicketByTitleAsync(string title);
        Task<IEnumerable<TicketDto>> GetTicketByStatusAsync(Enum status);
        Task<IEnumerable<TicketDto>> GetTicketByPriorityAsync(Enum priority);
        Task<IEnumerable<TicketDto>> GetTicketByCustomerAsync(Guid id);
        Task<IEnumerable<TicketDto>> GetTicketBySupportAgentAsync(Guid id);
        Task<IEnumerable<TicketDto>> GetTicketByCategoryAsync(Guid id);
    }
}
