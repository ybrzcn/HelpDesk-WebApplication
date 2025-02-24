using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class SupportAgentConfiguration : IEntityTypeConfiguration<SupportAgent>
{
    public void Configure(EntityTypeBuilder<SupportAgent> builder)
    {
        builder.HasKey(sa => sa.Id);
        builder.HasMany(sa => sa.AssignedTickets)
               .WithOne(t => t.AssignedToAgent)
               .HasForeignKey(t => t.AssignedToAgentId);
        builder.HasMany(sa => sa.AllowedCategories)
               .WithMany(tc => tc.AllowedAgents);
    }
}
