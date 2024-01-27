using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class ConsumoRestauranteFrigobar
    {
        [Key]
        public int codConsumo {get; set;}
        public Conta? numeroConta {get; set;}
        public string? descricao {get; set;}
        public double valor {get; set;}
        public bool restauranteEntregaQuarto {get; set;}
    }
}