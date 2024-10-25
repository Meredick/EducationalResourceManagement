using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EducationalResourceManagement.Infrastructure.Data;
using EducationalResourceManagement.Domain.Entities;

namespace EducationalResourceManagement.Application.Services
{
    public class CourseService
    {
        private readonly EducationalResourceContext _context;

        public CourseService(EducationalResourceContext context)
        {
            _context = context;
        }

        public void AssignMaterialToCourse(int courseId, int materialId)
        {
            var course = _context.Courses.Find(courseId);
            var material = _context.Materials.Find(materialId);

            if (course != null && material != null)
            {
                course.Materials ??= new List<Material>();
                course.Materials.Add(material);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.Teacher).ToList();
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
        }

        public void CreateCourse(Course course)
        {
            if (course != null)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
        }

        public void UpdateCourse(Course course)
        {
            if (course != null)
            {
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
