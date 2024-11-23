using EducationalResourceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EducationalResourceManagement.Domain.Repository
{
    public interface IMaterialRepository
    {
        Task<Material?> GetByIdAsync(int id);
        Task<IEnumerable<Material>> GetAllAsync();
        Task AddAsync(Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(int id);
    }
}
