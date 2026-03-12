using Microsoft.EntityFrameworkCore;
using Captain.Data;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Repositories;

public class FactoryRepository : IFactoryRepository
{
    private readonly AppDbContext _context;

    public FactoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Factory>> GetAllAsync()
    {
        return await _context.Factories
            .AsNoTracking()
            .Include(f => f.Address)
            .Include(f => f.Contact)
            .OrderBy(f => f.CompanyName)
            .ToListAsync();
    }

    public async Task<Factory?> GetByIdAsync(Guid id)
    {
        return await _context.Factories
            .Include(f => f.Address)
            .Include(f => f.Contact)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Factory> AddAsync(Factory factory)
    {
        _context.Factories.Add(factory);
        await _context.SaveChangesAsync();
        return factory;
    }

    public async Task<Factory> UpdateAsync(Factory factory)
    {
        _context.Factories.Update(factory);
        await _context.SaveChangesAsync();
        return factory;
    }

    public async Task DeleteAsync(Factory factory)
    {
        _context.Factories.Remove(factory);
        await _context.SaveChangesAsync();
    }
}