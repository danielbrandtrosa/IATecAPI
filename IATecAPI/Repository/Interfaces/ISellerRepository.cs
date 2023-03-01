using IATecAPI.Models;

namespace IATecAPI.Repository.Interfaces
{
    public interface ISellerRepository
    {
        Task<List<SellerModel>> GetAll();
        Task<SellerModel> GetById(int id);
        Task<SellerModel> Add(SellerModel seller);
        Task<SellerModel> Update (SellerModel seller, int id);
        Task<bool> Delete(int id);
    }
}
