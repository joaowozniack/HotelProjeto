using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class TipoQuarto
    {
        [Key]
        public int codTipo {get; set;}
        public string? tipo {get; set;}
        public int capcidadeMaxima {get; set;}
        public bool capacidadeOpcional {get; set;}
    }
}