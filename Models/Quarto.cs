using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Quarto
    {
        [Key]
        public int numeroQuarto {get; set;}
        public TipoQuarto? codTipoQuarto {get; set;}
        public double valorQuarto {get; set;}
    }
}