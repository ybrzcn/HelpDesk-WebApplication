using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Data;

public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SupportAgent> SupportAgents { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
    public DbSet<TicketLog> TicketLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserBaseConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupportAgentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketCategoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketCommentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketAttachmentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketLogConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
