using IATecAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace IATecAPI.Models
{
    public class SellerModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

    }
}
