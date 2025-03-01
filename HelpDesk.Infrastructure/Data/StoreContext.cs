using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class StoreContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SupportAgent> SupportAgents { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
    public DbSet<TicketLog> TicketLogs { get; set; }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
        var connStr = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connStr, options =>
        {
            options.CommandTimeout(5_000);
            options.EnableRetryOnFailure(maxRetryCount: 5);
        });
    }
}
