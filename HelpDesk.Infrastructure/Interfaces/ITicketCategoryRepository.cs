using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketCategoryRepository : IBaseRepository<TicketCategory, TicketCategoryDto>
    {
        Task<IEnumerable<TicketCategoryDto>> GetTicketCategoryByNameAsync(string name);
    }
}
