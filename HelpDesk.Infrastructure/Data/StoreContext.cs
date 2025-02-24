using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }
}