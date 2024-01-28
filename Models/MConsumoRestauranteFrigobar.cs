using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MConsumoRestauranteFrigobar
    {
        [Key]
        public int CodConsumo {get; set;}
        public MConta? Conta {get; set;}
        [MaxLength(50)]
        public string? Descricao {get; set;}
        public double Valor {get; set;}
        public bool RestauranteEntregaQuarto {get; set;}


        public MConsumoRestauranteFrigobar() {

        }

        public MConsumoRestauranteFrigobar(MConta conta, string descricao, double valor, bool restauranteEntregaQuarto) {
            this.Conta = conta;
            this.Descricao = descricao;
            this.Valor = valor;
            this.RestauranteEntregaQuarto = restauranteEntregaQuarto;
        }
    }
}