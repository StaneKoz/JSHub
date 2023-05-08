using JSHub.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSHub.Dal.ETG
{
    public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles").HasKey(u => u.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(p => p.Projects)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.ProfileId)
                .HasPrincipalKey(p => p.Id);

            builder.HasMany(p => p.Specializations)
                .WithMany(p => p.Profiles);

            builder.Property(u => u.Age).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired();
            builder.Property(u => u.AboutMe);
        }
    }
}
