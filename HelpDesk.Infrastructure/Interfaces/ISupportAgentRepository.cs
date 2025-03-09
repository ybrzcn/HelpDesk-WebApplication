using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ISupportAgentRepository : IBaseRepository<SupportAgent, SupportAgentDto>
    {
        Task<IEnumerable<SupportAgentDto>> GetSupportAgentByEmailAsync(string email);
        Task<IEnumerable<SupportAgentDto>> GetSupportAgentByUserNameAsync(string userName);
    }
}
