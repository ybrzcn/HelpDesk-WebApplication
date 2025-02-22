namespace HelpDesk.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public ICollection<UserCategory> UserCategories { get; set; }
}
