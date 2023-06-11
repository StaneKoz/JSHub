using Portfolio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Dal.ETG
{
    public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles").HasKey(u => u.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            // у профиля есть множество проектов
            builder.HasMany(p => p.Projects)
            // у проекта есть только один профиль
                .WithOne(p => p.Profile)
            // внешний ключ проекта
                .HasForeignKey(p => p.ProfileId)
            // главный ключ в сущности профиля
                .HasPrincipalKey(p => p.Id);

            builder.HasMany(p => p.Specializations)
                .WithMany(p => p.Profiles);

            builder.HasOne(p => p.Avatar);

            builder.Property(u => u.Age).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired();
            builder.Property(u => u.AboutMe);
        }
    }
}
