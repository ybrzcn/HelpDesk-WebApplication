namespace HelpDesk.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool Show => !IsDeleted && IsActive;

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
