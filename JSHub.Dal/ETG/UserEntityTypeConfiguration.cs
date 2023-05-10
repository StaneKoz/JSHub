using Portfolio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Dal.ETG
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            // В главной сущности - одно навигационное свойство - профиль
            builder.HasOne(u => u.Profile)
            // В зависимой сущности - одно навигационное свойство - юзер
            .WithOne(u => u.User)
            // Профиль связан с юзером через внешний ключ UserId
            .HasForeignKey<Profile>(p => p.UserId);

        }
    }
}
