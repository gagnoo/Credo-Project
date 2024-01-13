using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations.User;

public class UserTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.UserEntity.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.UserEntity.User> builder)
    {
        builder.ToTable(TableNames.UserTable);

        builder.HasKey(i => i.UserId);

        builder.Property(i => i.Name)
               .HasColumnType(DbTypes.Nvarchar)
               .HasMaxLength(32)
               .IsRequired();
    }
}