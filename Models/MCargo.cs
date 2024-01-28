using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MCargo
    {
        [Key]
        public int CodCargo {get; set;}
        [MaxLength(15)]
        public string? NomeCargo {get; set;}
    }
}