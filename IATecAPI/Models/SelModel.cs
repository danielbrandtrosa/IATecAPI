using IATecAPI.Enums;

namespace IATecAPI.Models
{
    public class SelModel
    {
        public int Id { get; set; }
        public StatusVenda Status { get; set; }
        public int Identificador { get; set; }


        public int? SellerId { get; set; }
        public virtual SellerModel Seller { get; set; }


        //public ICollection<SelItemModel> SelItens { get; set; }


    }
}
