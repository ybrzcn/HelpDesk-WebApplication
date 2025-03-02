using HelpDesk.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config.BaseConfig;

public class UserBaseConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : UserBase
{
       public void Configure(EntityTypeBuilder<TEntity> builder)
       {
            base.Configure(builder);

            builder.Property(x => x.FullName)
                     .HasMaxLength(25)
                     .IsRequired();

            builder.Property(x => x.UserName)
                   .HasMaxLength(25)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(50)
                   .IsRequired();
       }
}
