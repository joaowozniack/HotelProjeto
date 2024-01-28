using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MFilial
    {
        [Key]
        public int CodFilial {get; set;}
        [MaxLength(30)]
        public string? Nome {get; set;}
        public MEndereco? Endereco {get; set;}
        public int QuantidadeQuartoSolteiro {get; set;}
        public int QuantidadeQuartoCasal {get; set;}
        public int QuantidadeQuartoFamilia {get; set;}
        public int QuantidadeQuartoPresidencial {get; set;}
        public int QuantidadeEstrelas {get; set;}

        public MFilial() {

        }

        public MFilial(string nome, MEndereco endereco, int quantidadeQuartoSolteiro, int quantidadeQuartoCasal,
        int quantidadeQuartoFamilia, int quantidadeQuartoPresidencial, int quantidadeEstrelas) {
            this.Nome = nome;
            this.Endereco = endereco;
            this.QuantidadeQuartoSolteiro = quantidadeQuartoSolteiro;
            this.QuantidadeQuartoCasal = quantidadeQuartoCasal;
            this.QuantidadeQuartoFamilia = quantidadeQuartoFamilia;
            this.QuantidadeQuartoPresidencial = quantidadeQuartoPresidencial;
            this.QuantidadeEstrelas = quantidadeEstrelas;
        }
    }
}