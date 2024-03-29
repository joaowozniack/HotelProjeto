using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MFormaPagamento 
    {
        [Key]
        public int CodForma {get; set;}
        [MaxLength(20)]
        public string? Forma {get; set;}

        public MFormaPagamento() {

        }

        public MFormaPagamento(string forma) {
            this.Forma = forma;
        }
    }

}