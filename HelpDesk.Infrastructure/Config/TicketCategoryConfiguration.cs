using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class TicketCategoryConfiguration : BaseEntityConfiguration<TicketCategory>
{
    public void Configure(EntityTypeBuilder<TicketCategory> builder)
    {
        builder.ToTable("TicketCategories");

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasMany(x => x.Tickets)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.AllowedAgents)
               .WithMany(x => x.AllowedCategories);

        builder.HasMany(x => x.AllowedCustomers)
               .WithMany(x => x.AllowedCategories);

        base.Configure(builder);
    }
}