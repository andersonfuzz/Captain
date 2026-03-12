using Microsoft.EntityFrameworkCore;
using Captain.Data;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Repositories;

public class ListRepository : IListRepository
{
    private readonly AppDbContext _context;

    public ListRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Entities.List>> GetAllAsync()
    {
        return await _context.Lists
            .AsNoTracking()
            .Include(l => l.Factory)
            .Include(l => l.Items)
            .OrderBy(l => l.Name)
            .ToListAsync();
    }

    public async Task<Entities.List?> GetByIdAsync(Guid id)
    {
        return await _context.Lists
            .Include(l => l.Factory)
            .Include(l => l.Items)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

 public async Task<Entities.List> AddAsync(Entities.List list)
{
    _context.Lists.Add(list);
    await _context.SaveChangesAsync();

    return await _context.Lists
        .Include(l => l.Factory)
        .Include(l => l.Items)
        .FirstAsync(l => l.Id == list.Id);
}

    public async Task<Entities.List> UpdateAsync(Entities.List list)
    {
        _context.Lists.Update(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task DeleteAsync(Entities.List list)
    {
        _context.Lists.Remove(list);
        await _context.SaveChangesAsync();
    }
}