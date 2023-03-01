using System.ComponentModel.DataAnnotations;

namespace IATecAPI.Models
{
    public class SelItemModel
    {
        public int Id { get; set; }

        [Required]
        public string Titule { get; set; }
        
        [Required]
        public int Price { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int SelID { get; set; }
        public SelModel Sel { get; set; }
    }
}
