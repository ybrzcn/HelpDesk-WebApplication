using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Tickets)
               .WithOne(t => t.Customer)
               .HasForeignKey(t => t.CustomerId);
        builder.HasMany(c => c.AllowedCategories)
               .WithMany(tc => tc.AllowedCustomers);
    }
}
