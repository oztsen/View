using MNSBI2.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MNSBI2.Data.Repositories
{
    public interface IBIViewRepository
    {
        Task<IEnumerable<BIView>> GetAllAsync();
        Task<BIView> GetByIdAsync(Guid id);
        Task<BIView> AddAsync(BIView biView);
        Task UpdateAsync(BIView biView);
        Task DeleteAsync(Guid id);
    }
}