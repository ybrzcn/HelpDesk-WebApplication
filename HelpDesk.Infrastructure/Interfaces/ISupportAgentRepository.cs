using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ISupportAgentRepository : IBaseRepository<SupportAgent, SupportAgentDto>
    {
        Task<SupportAgentDto> GetSupportAgentByEmailAsync(string email);
        Task<SupportAgentDto> GetSupportAgentByUserNameAsync(string userName);
    }
}
