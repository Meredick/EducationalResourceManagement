using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Domain.Entities
{
    public class Material
    {
        public int Id { get; set; } 
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public DateTime? UploadDate { get; set; } 
        public string? FilePath { get; set; }
        public int CourseId { get; set; }

        public Course? Course { get; set; }

        public ICollection<ResourceAccess>? Accesses { get; set; }
    }
}
