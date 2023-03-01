using IATecAPI.Data;
using IATecAPI.Models;
using IATecAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IATecAPI.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly IATecDbContext _dbContext;
        public SellerRepository(IATecDbContext iatecDbContext)
        {
            _dbContext = iatecDbContext;
        }



         public async Task<SellerModel> GetById(int id)
        {
            return await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == id);
        } 
        
        public async Task<List<SellerModel>> GetAll()
        {
            return await _dbContext.Sellers.ToListAsync();
        }




        public async Task<SellerModel> Add(SellerModel seller)
        {
            await _dbContext.Sellers.AddAsync(seller);
            await _dbContext.SaveChangesAsync();

            return seller;
        }
        public async Task<SellerModel> Update(SellerModel seller, int id)
        {
            SellerModel sellerById = await GetById(id);
            if (sellerById == null)
            {
                throw new Exception($"Seller Id {id} not found in Base.");
            }
            sellerById.Name = seller.Name;
            sellerById.Cpf = seller.Cpf;

            _dbContext.Sellers.Update(sellerById);
            await _dbContext.SaveChangesAsync();

            return sellerById;
        }


        public async Task<bool> Delete(int id)
        {
            SellerModel sellerById = await GetById(id);
            if (sellerById == null)
            {
                throw new Exception($"Seller Id {id} not found in Base.");
            }

            _dbContext.Sellers.Remove(sellerById);
            await _dbContext.SaveChangesAsync();

            return true;
        }




    }
}
