using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ITicketCategoryRepository : IBaseRepository<TicketCategory, TicketCategoryDto>
    {
        Task<TicketCategoryDto> GetTicketCategoryByNameAsync(string name);
    }
}
