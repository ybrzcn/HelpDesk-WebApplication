using HelpDesk.Core.Entities;
using HelpDesk.Core.Entities.BaseEntities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using HelpDesk.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Contexts;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<SupportAgent> SupportAgents { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<TicketLog> TicketLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // BaseEntity veya UserBase'i Model’e ekleme
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.Ignore<UserBase>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
    }
}
