namespace HelpDesk.Core.Entities.BaseEntities;

public abstract class UserBase
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool Show { get; set; }
}
