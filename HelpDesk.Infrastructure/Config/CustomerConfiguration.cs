using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Tickets)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);

        builder.HasMany(x => x.AllowedCategories)
               .WithMany(x => x.AllowedCustomers);
    }
}
