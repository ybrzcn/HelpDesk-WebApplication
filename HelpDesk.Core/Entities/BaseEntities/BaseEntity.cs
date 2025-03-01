namespace HelpDesk.Core.Entities.BaseEntities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifideDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool Show { get; set; }
}
