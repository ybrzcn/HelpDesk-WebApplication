using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Config.BaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class CustomerConfiguration : UserBaseConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(x => x.Tickets)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);

        builder.HasMany(x => x.AllowedCategories)
               .WithMany(x => x.AllowedCustomers);

        base.Configure(builder);
    }
}
