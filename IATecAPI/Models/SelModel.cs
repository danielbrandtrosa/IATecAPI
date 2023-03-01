using IATecAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace IATecAPI.Models
{
    public class SelModel
    {
        public int Id { get; set; }
        
        //[Required]
        public StatusVenda Status { get; set; }
        
        //[Required]
        public int Identificador { get; set; }


        public int SellerId { get; set; }
        public virtual SellerModel? Seller { get; set; }


        //public ICollection<SelItemModel> SelItens { get; set; }


    }
}
