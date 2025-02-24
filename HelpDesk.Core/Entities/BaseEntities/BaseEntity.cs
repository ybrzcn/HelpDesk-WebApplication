namespace HelpDesk.Core.Entities.BaseEntities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifideDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool Show { get; set; }
}
