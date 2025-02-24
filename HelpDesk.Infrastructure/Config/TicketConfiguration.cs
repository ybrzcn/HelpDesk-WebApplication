using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
       public void Configure(EntityTypeBuilder<Ticket> builder)
       {
              builder.HasKey(x => x.Id);

              builder.Property(x => x.Title)
                     .IsRequired()
                     .HasMaxLength(200);

              builder.Property(x => x.Description)
                     .IsRequired()
                     .HasMaxLength(2000);

              builder.Property(x => x.Status)
                     .HasDefaultValue(TicketStatus.Open);

              builder.Property(x => x.Priority)
                     .HasDefaultValue(TicketPriority.Medium);

              builder.HasOne(x => x.Customer)
                     .WithMany(x => x.Tickets)
                     .HasForeignKey(x => x.CustomerId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.AssignedToAgent)
                     .WithMany(x => x.AssignedTickets)
                     .HasForeignKey(x => x.AssignedToAgentId)
                     .OnDelete(DeleteBehavior.SetNull);

              builder.HasOne(x => x.Category)
                     .WithMany(x => x.Tickets)
                     .HasForeignKey(x => x.CategoryId);

              builder.HasMany(x => x.Comments)
                     .WithOne(x => x.Ticket)
                     .HasForeignKey(x => x.TicketId);

              builder.HasIndex(x => x.Status);
              builder.HasIndex(x => x.Priority);
              builder.HasIndex(x => x.CustomerId);
              builder.HasIndex(x => x.AssignedToAgentId);
       }
}
