using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class SupportAgentConfiguration : UserBaseConfiguration<SupportAgent>
{
    public void Configure(EntityTypeBuilder<SupportAgent> builder)
    {
        builder.HasMany(x => x.AssignedTickets)
               .WithOne(x => x.AssignedToAgent)
               .HasForeignKey(x => x.AssignedToAgentId);

        builder.HasMany(x => x.AllowedCategories)
               .WithMany(x => x.AllowedAgents);

        base.Configure(builder);
    }
}
