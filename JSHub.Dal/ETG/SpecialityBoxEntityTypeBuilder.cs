using JSHub.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSHub.Dal.ETG
{
    public class SpecialityBoxEntityTypeBuilder : IEntityTypeConfiguration<SpecialityBox>
    {
        public void Configure(EntityTypeBuilder<SpecialityBox> builder)
        {
            builder.ToTable("Specializations").HasKey(s => s.Id);

            builder.HasMany(s => s.Profiles)
                .WithMany(p => p.Specializations);

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
