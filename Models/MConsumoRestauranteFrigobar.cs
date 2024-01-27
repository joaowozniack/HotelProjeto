using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MConsumoRestauranteFrigobar
    {
        [Key]
        public int codConsumo {get; set;}
        public MConta? numeroConta {get; set;}
        public string? descricao {get; set;}
        public double valor {get; set;}
        public bool restauranteEntregaQuarto {get; set;}
    }
}