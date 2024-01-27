using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MFuncionario
    {
        [Key]
        public int codFuncionario {get; set;}
        public MCargo? codCargo {get; set;}
        public string? nome {get; set;}

    }
}