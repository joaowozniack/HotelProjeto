using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Pagamento
    {
        [Key]
        public int codPagamento {get; set;}
        public FormaPagamento? codForma {get; set;}
        public Conta? numeroConta {get; set;}
    }
}