using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketLogConfiguration : BaseEntityConfiguration<TicketLog>
{
    public void Configure(EntityTypeBuilder<TicketLog> builder)
    {
        builder.ToTable("TicketLogs");

        builder.Property(x => x.Action)
               .HasDefaultValue(TicketAction.Created);

        builder.HasOne(x => x.Ticket)
               .WithMany()
               .HasForeignKey(x => x.TicketId);

        builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId);

        base.Configure(builder);
    }
}
