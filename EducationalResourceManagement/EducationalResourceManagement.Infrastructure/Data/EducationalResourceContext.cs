using Microsoft.EntityFrameworkCore;
using EducationalResourceManagement.Domain.Entities;
using System.Collections.Generic;

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
    }
}
