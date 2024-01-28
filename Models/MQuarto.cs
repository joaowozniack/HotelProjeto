using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MQuarto
    {
        [Key]
        public int NumeroQuarto {get; set;}
        public MTipoQuarto? TipoQuarto {get; set;}
        public double ValorQuarto {get; set;}

        public MQuarto(){

        }

        public MQuarto(MTipoQuarto tipoQuarto, double valorQuarto){
            this.TipoQuarto = tipoQuarto;
            this.ValorQuarto = valorQuarto;
        }
    }
}