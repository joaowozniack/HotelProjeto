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
        public ICollection<MQuartosFilial>? QuartosFilial { get; set; } = new List<MQuartosFilial>();
        public int QuantidadeEstrelas {get; set;}
    }
}