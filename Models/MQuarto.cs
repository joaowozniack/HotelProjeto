using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MQuarto
    {
        [Key]
        public int numeroQuarto {get; set;}
        public MTipoQuarto? codTipoQuarto {get; set;}
        public double valorQuarto {get; set;}
    }
}