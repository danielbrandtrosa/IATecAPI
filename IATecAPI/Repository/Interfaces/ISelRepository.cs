using IATecAPI.Models;

namespace IATecAPI.Repository.Interfaces
{
    public interface ISelRepository
    {
        Task<SelModel> Add(SelModel sel);
        Task<SelModel> GetById(int id);
        Task<SelModel> UpdateStatus(SelModel sel, int id);
    }
}
