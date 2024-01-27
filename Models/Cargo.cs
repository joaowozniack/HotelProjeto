using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Cargo
    {
        [Key]
        public int codCargo {get; set;}
        public string? nomeCargo {get; set;}
    }
}