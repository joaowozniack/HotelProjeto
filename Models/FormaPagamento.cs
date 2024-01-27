using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class FormaPagamento 
    {
        [Key]
        public int codForma {get; set;}
        public string? forma {get; set;}
    }
}