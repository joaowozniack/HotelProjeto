using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MCargo
    {
        [Key]
        public int codCargo {get; set;}
        public string? nomeCargo {get; set;}
    }
}