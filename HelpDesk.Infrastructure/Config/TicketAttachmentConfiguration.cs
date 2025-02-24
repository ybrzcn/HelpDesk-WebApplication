using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
{
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
               .IsRequired()
               .HasMaxLength(255);
        builder.Property(x => x.FilePath)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasOne(x => x.Ticket)
               .WithMany(x => x.Attachments)
               .HasForeignKey(x => x.TicketId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.TicketId);
    }
}
