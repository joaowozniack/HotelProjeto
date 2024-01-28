using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MFuncionario
    {
        [Key]
        public int CodFuncionario {get; set;}

        public MCargo? Cargo {get; set;}
        [MaxLength(45)]
        public string? Nome {get; set;}

        public MFuncionario(){

        }

        public MFuncionario(MCargo cargo, string nome){
            this.Cargo = cargo;
            this.Nome = nome;
        }

    }
}