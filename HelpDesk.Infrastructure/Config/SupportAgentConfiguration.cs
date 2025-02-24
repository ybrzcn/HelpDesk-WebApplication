using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class SupportAgentConfiguration : IEntityTypeConfiguration<SupportAgent>
{
    public void Configure(EntityTypeBuilder<SupportAgent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.AssignedTickets)
               .WithOne(x => x.AssignedToAgent)
               .HasForeignKey(x => x.AssignedToAgentId);

        builder.HasMany(x => x.AllowedCategories)
               .WithMany(x => x.AllowedAgents);
    }
}
