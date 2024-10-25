using EducationalResourceManagement.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Infrastructure.Data
{
    public static class AppDbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<EducationalResourceContext>())
            {
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course { Title = "Math 101", TeacherId = 1 },
                        new Course { Title = "Physics 101", TeacherId = 2 }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}