using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketAttachmentConfiguration : BaseEntityConfiguration<TicketAttachment>
{
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
        builder.ToTable("TicketAttachments");

        builder.Property(x => x.FileName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.FilePath)
               .IsRequired()
               .HasMaxLength(300);

        builder.HasOne(x => x.Ticket)
               .WithMany(x => x.Attachments)
               .HasForeignKey(x => x.TicketId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.TicketId);

        base.Configure(builder);
    }
}
