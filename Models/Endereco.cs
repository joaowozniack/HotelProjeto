using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Endereco
    {
        [Key]
        public int codEndereco {get; set;}
        public string? rua {get; set;}
        public int numero {get; set;}
        public string? bairro {get; set;}
        public string? cidade {get; set;}
        public string? estado {get; set;}
    }
}