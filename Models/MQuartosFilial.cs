using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto
{
    public class MQuartosFilial
    {
        [Key]
        public int CodQuartosFilial {get; set;}
        public MFilial? Filial {get; set;}
        public MTipoQuarto? TipoQuarto {get; set;}
        public int QuantidadeQuartos {get; set;}
        public double ValorQuarto {get; set;}
    }
}