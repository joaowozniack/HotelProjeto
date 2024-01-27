using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Reserva
    {
        [Key]
        public int codReserva {get; set;}
        public Quarto? numeroQuarto {get; set;}
        public Funcionario? codFuncionario {get; set;}
        public Cliente? codCliente {get; set;}
        public DateOnly dataCheckin {get; set;}
        public DateOnly dataCheckout {get; set;}
    }
}