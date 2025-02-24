using HelpDesk.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Config.BaseConfig;

public class UserBaseConfiguration : IEntityTypeConfiguration<UserBase>
{
       public void Configure(EntityTypeBuilder<UserBase> builder)
       {
              builder.HasKey(x => x.Id);

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
