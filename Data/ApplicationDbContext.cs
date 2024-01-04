
using Microsoft.EntityFrameworkCore;
using SMSApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Qualification>? Qualifications { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Qualifications)
                .WithOne(q => q.Student)
                .HasForeignKey(q => q.StudentId);

            modelBuilder.Entity<Qualification>()
                .Property(q => q.Percentage)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Admin>().ToTable("Admins");
            // Additional configurations if needed
            DataSeeder.SeedAdminData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
