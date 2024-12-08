using Microsoft.EntityFrameworkCore;
using EducationalResourceManagement.Domain.Entities;

namespace EducationalResourceManagement.Infrastructure.Data
{
    public class EducationalResourceContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ResourceAccess> ResourceAccesses { get; set; }

        public EducationalResourceContext(DbContextOptions<EducationalResourceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "tu_cadena_de_conexion",
                    b => b.MigrationsAssembly("EducationalResourceManagement.Infrastructure"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(200);

                entity.HasOne(c => c.Teacher)
                      .WithMany(t => t.Courses)
                      .HasForeignKey(c => c.TeacherId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Title).IsRequired().HasMaxLength(200);
                entity.Property(m => m.Description).HasMaxLength(1000);
                entity.Property(m => m.FilePath).HasMaxLength(500);
                entity.Property(m => m.UploadDate).IsRequired();

                entity.HasOne(m => m.Course)
                      .WithMany(c => c.Materials)
                      .HasForeignKey(m => m.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ResourceAccess>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(r => r.Student)
                      .WithMany(s => s.Accesses)
                      .HasForeignKey(r => r.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Material)
                      .WithMany(m => m.Accesses)
                      .HasForeignKey(r => r.MaterialId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
