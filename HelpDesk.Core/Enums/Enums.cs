namespace HelpDesk.Core.Enums;

public enum AgentRole
{
    SupportAgent,
    Admin
}

public enum TicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed
}

public enum TicketPriority
{
    Low,
    Medium,
    High,
    Critical
}

public enum TicketAction
{
    Created,
    Updated,
    Deleted,
    Assigned,
    Commented,
    AttachmentAdded
}
