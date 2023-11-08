using MNSBI2.Core.Models;
using MNSBI2.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MNSBI2.Data.Repositories
{
    public class BIViewRepository : IBIViewRepository
    {
        private readonly ApplicationDbContext _context;

        public BIViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BIView>> GetAllAsync()
        {
            return await _context.BIViews.ToListAsync();
        }

        public async Task<BIView> GetByIdAsync(Guid id)
        {
            return await _context.BIViews.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BIView> AddAsync(BIView biView)
        {
            _context.BIViews.Add(biView);
            await _context.SaveChangesAsync();
            return biView;
        }

        public async Task UpdateAsync(BIView biView)
        {
            _context.Entry(biView).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var biView = await GetByIdAsync(id);
            if (biView != null)
            {
                _context.BIViews.Remove(biView);
                await _context.SaveChangesAsync();
            }
        }
    }
}