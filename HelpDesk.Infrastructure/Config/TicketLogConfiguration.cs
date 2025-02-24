using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketLogConfiguration : IEntityTypeConfiguration<TicketLog>
{
    public void Configure(EntityTypeBuilder<TicketLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Ticket)
               .WithMany()
               .HasForeignKey(x => x.TicketId);

        builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId);
    }
}
