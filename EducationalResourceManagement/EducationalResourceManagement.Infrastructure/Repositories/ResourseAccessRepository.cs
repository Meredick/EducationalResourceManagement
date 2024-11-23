using Microsoft.EntityFrameworkCore;
using EducationalResourceManagement.Infrastructure.Data;
using EducationalResourceManagement.Domain.Entities;
using EducationalResourceManagement.Domain.Repository;

namespace EducationalResourceManagement.Infrastructure.Repositories
{
    public class ResourceAccessRepository : IResourceAccessRepository
    {
        private readonly EducationalResourceContext _context;

        public ResourceAccessRepository(EducationalResourceContext context)
        {
            _context = context;
        }

        public async Task<ResourceAccess?> GetByIdAsync(int id)
        {
            return await _context.ResourceAccesses.FindAsync(id);
        }

        public async Task<IEnumerable<ResourceAccess>> GetAllAsync()
        {
            return await _context.ResourceAccesses.ToListAsync();
        }

        public async Task AddAsync(ResourceAccess resourceAccess)
        {
            await _context.ResourceAccesses.AddAsync(resourceAccess);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ResourceAccess resourceAccess)
        {
            _context.ResourceAccesses.Update(resourceAccess);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var resourceAccess = await GetByIdAsync(id);
            if (resourceAccess != null)
            {
                _context.ResourceAccesses.Remove(resourceAccess);
                await _context.SaveChangesAsync();
            }
        }
    }
}
