using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Domain.Entities
{
    public class ResourceAccess
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public DateTime AccessDate { get; set; }
    }
}
