using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MPagamento
    {
        [Key]
        public int codPagamento {get; set;}
        public MFormaPagamento? codForma {get; set;}
        public MConta? numeroConta {get; set;}
    }
}