using IATecAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace IATecAPI.Models
{
    public class SelModel
    {
        //private SelModel() { }

        public int Id { get; set; }

        [Required]
        public StatusVenda Status { get; set; }

        [Required]
        public int Identificador { get; set; }


        [Required]
        public int SellerId { get; set; }
        public virtual SellerModel? Seller { get; set; }


        public ICollection<SelItemModel> SelItens { get; set; }

        public bool BlockUpdate(StatusVenda newStatus)
        {
            bool valStatus = true;
            switch (Status)
            {
                case StatusVenda.AguardandoPagamento:
                    if (newStatus == StatusVenda.PagamentoAprovado || newStatus == StatusVenda.Cancelada)
                        valStatus = false;
                    break;
                case StatusVenda.PagamentoAprovado:
                    if (newStatus == StatusVenda.Enviado || newStatus == StatusVenda.Cancelada)
                        valStatus = false;
                    break;
                case StatusVenda.Cancelada:
                    break;
                case StatusVenda.Enviado:
                    if (newStatus == StatusVenda.Entregue)
                    valStatus = false;
                    break;
                case StatusVenda.Entregue:
                    break;
                default:
                    break;
            }

            return valStatus;
        }
    }
}
