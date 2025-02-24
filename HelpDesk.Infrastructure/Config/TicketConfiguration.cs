using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Customer)
               .WithMany(c => c.Tickets)
               .HasForeignKey(t => t.CustomerId);

        builder.HasOne(t => t.Category)
               .WithMany(tc => tc.Tickets)
               .HasForeignKey(t => t.CategoryId);
    }
}
