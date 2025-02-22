using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Status)
            .HasForeignKey(x => x.StatusId);
    }
}
