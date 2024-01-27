using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Funcionario
    {
        [Key]
        public int codFuncionario {get; set;}
        public Cargo? codCargo {get; set;}
        public string? nome {get; set;}

    }
}