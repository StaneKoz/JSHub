using JSHub.Domain.Entity;
using JSHub.Domain.Enum;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JSHub.Dal
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { 
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(u => u.Id);

                builder.Property(u => u.Id).ValueGeneratedOnAdd();
                builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
                builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

                builder.HasOne(u => u.Profile)
                .WithOne(u => u.User)
                .HasPrincipalKey<User>(u => u.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(u => u.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(u => u.Age).IsRequired();
                builder.Property(u => u.FirstName).IsRequired();
                builder.Property(u => u.LastName).IsRequired();
                builder.Property(u => u.AboutMe);
                builder.Property(u => u.PhoneNumber).IsRequired();
                builder.Property(u => u.Speciality).IsRequired();
            });
        }
    }
}
