using Microsoft.EntityFrameworkCore;
using EducationalResourceManagement.Infrastructure.Data;
using EducationalResourceManagement.Domain.Entities;
using EducationalResourceManagement.Domain.Repository;

namespace EducationalResourceManagement.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EducationalResourceContext _context;

        public StudentRepository(EducationalResourceContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}

