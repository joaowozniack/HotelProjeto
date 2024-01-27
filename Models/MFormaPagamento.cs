using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MFormaPagamento 
    {
        [Key]
        public int codForma {get; set;}
        public string? forma {get; set;}
    }
}