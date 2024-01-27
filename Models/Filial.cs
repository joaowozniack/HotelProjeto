using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Filial
    {
        [Key]
        public int codFilial {get; set;}
        public string? nome {get; set;}
        public Endereco? codEndereco {get; set;}
        public int numeroQuartoSolteiro {get; set;}
        public double valorQuartoSolteiro {get; set;}
        public int numeroQuartoCasal {get; set;}
        public double valorQuartoCasal {get; set;}
        public int numeroQuartoFamilia {get; set;}
        public double valorQuartoFamilia {get; set;}
        public int numeroQuartoPresidencial {get; set;}
        public double valorQuartoPresidencial {get; set;}
        public int quantidadeEstrelas {get; set;}
    }
}