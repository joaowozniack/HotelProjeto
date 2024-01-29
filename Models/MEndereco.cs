using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MEndereco
    {
        [Key]
        public int CodEndereco {get; set;}
        [MaxLength(60)]
        public string? Rua {get; set;}
        public int Numero {get; set;}
        [MaxLength(30)]
        public string? Bairro {get; set;}
        [MaxLength(30)]
        public string? Cidade {get; set;}
        [MaxLength(30)]
        public string? Estado {get; set;}

        public MEndereco() {

        }

        public MEndereco(string rua, int numero, string bairro, string cidade, string Estado) {

        }

    }
}