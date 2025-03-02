using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class CustomerConfiguration : UserBaseConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.HasMany(c => c.Tickets)
              .WithOne(t => t.Customer)
              .HasForeignKey(t => t.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.AllowedCategories)
               .WithMany(x => x.AllowedCustomers);
    }
}
