using Microsoft.EntityFrameworkCore;
using Captain.Data;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.Items
            .AsNoTracking()
            .Where(i => ids.Contains(i.Id))
            .ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await _context.Items.FindAsync(id);
    }
}