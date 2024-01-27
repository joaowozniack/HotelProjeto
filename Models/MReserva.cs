using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MReserva
    {
        [Key]
        public int codReserva {get; set;}
        public MQuarto? numeroQuarto {get; set;}
        public MFuncionario? codFuncionario {get; set;}
        public MCliente? codCliente {get; set;}
        public DateOnly dataCheckin {get; set;}
        public DateOnly dataCheckout {get; set;}
    }
}