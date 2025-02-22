using HelpDesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(c => c.UserCategories)
            .WithOne(uc => uc.Category)
            .HasForeignKey(uc => uc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
