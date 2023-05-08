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
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SpecialityBox> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
