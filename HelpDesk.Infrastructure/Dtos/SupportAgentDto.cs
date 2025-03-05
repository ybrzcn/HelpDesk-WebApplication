using HelpDesk.Core.Enums;

namespace HelpDesk.Infrastructure.Dtos
{
    public class SupportAgentDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AgentRole Role { get; set; }
    }
}
