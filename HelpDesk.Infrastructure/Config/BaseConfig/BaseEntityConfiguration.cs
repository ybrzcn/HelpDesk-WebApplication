using HelpDesk.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config.BaseConfig;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
       public void Configure(EntityTypeBuilder<TEntity> builder)
       {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDate)
                   .HasColumnType("datetime2");

            builder.Property(x => x.ModifideDate)
                   .HasColumnType("datetime2")
                   .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.Show)
                   .HasDefaultValue(true);
       }
}
