using IATecAPI.Data;
using IATecAPI.Models;
using IATecAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IATecAPI.Repository
{
    public class SelRepository : ISelRepository
    {
        private readonly IATecDbContext _dbContext;
        public SelRepository(IATecDbContext iatecDbContext)
        {
            _dbContext = iatecDbContext;
        }

        public async Task<SelModel> Add(SelModel sel)
        {
            await _dbContext.Sels.AddAsync(sel);
            await _dbContext.SaveChangesAsync();

            return sel;
        }

        public async Task<SelModel> GetById(int id)
        {
            return await _dbContext.Sels
                        .Include(x => x.Seller)
                        .Include(x => x.SelItens)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SelModel> UpdateStatus(SelModel sel, int id)
        {
            SelModel selById = await GetById(id);
            if (selById == null)
            {
                throw new Exception($"Sel Id: {id} not found, can't by updated.");
            }

            //selById.Id = id;
            selById.Status = sel.Status;

            _dbContext.Sels.Update(selById);
            await _dbContext.SaveChangesAsync();

            return selById;
        }
    }
}
