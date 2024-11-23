using EducationalResourceManagement.Domain.Entities;
using EducationalResourceManagement.Domain.Repository;
using EducationalResourceManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



public class MaterialRepository : IMaterialRepository
{
    private readonly EducationalResourceContext _context;

    public MaterialRepository(EducationalResourceContext context)
    {
        _context = context;
    }

    public async Task<Material?> GetByIdAsync(int id)
    {
        return await _context.Materials.FindAsync(id);
    }

    public async Task<IEnumerable<Material>> GetAllAsync()
    {
        return await _context.Materials.ToListAsync();
    }

    public async Task AddAsync(Material material)
    {
        await _context.Materials.AddAsync(material);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Material material)
    {
        _context.Materials.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var material = await GetByIdAsync(id);
        if (material != null)
        {
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }
    }
}

