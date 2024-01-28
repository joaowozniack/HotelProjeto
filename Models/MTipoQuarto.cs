using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MTipoQuarto
    {
        [Key]
        public int CodTipo {get; set;}
        [MaxLength(15)]
        public string? Tipo {get; set;}
        public int CapacidadeMaxima {get; set;}
        public bool CapacidadeOpcional {get; set;}
    }
}