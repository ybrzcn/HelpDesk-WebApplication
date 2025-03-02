namespace HelpDesk.Core.Entities.BaseEntities;

public abstract class UserBase : BaseEntity
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
