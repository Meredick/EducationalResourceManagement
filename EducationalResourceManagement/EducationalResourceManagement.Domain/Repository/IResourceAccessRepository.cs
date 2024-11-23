using EducationalResourceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalResourceManagement.Domain.Repository
{
    public interface IResourceAccessRepository
    {
        Task<ResourceAccess?> GetByIdAsync(int id);
        Task<IEnumerable<ResourceAccess>> GetAllAsync();
        Task AddAsync(ResourceAccess ResourceAccess);
        Task UpdateAsync(ResourceAccess ResourceAccess);
        Task DeleteAsync(int id);

    }
}
