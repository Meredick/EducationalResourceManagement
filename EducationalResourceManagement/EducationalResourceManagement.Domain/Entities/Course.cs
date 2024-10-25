﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Material>? Materials { get; set; }
    }
}
