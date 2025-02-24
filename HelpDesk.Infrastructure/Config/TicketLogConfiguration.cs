using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketLogConfiguration : IEntityTypeConfiguration<TicketLog>
{
    public void Configure(EntityTypeBuilder<TicketLog> builder)
    {
        builder.HasKey(tl => tl.Id);
        builder.HasOne(tl => tl.Ticket)
               .WithMany()
               .HasForeignKey(tl => tl.TicketId);
        builder.HasOne(tl => tl.User)
               .WithMany()
               .HasForeignKey(tl => tl.UserId);
    }
}
