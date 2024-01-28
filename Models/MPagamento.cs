using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MPagamento
    {
        [Key]
        public int CodPagamento {get; set;}
        public MFormaPagamento? Forma {get; set;}
        public MConta? NumeroConta {get; set;}
        
    }
}