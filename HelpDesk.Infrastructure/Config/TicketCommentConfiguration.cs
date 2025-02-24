using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Ticket)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.TicketId);
    }
}
