using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<ResourceAccess>? Accesses { get; set; }
    }
}
