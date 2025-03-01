using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketCommentConfiguration : BaseEntityConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        builder.ToTable("TicketComments");

        builder.Property(x => x.Content)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasOne(x => x.Ticket)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.TicketId);

        builder.HasOne(x => x.Author)
               .WithMany()
               .HasForeignKey(x => x.AuthorId);

        base.Configure(builder);
    }
}
