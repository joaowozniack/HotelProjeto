using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MReserva
    {
        [Key]
        public int CodReserva {get; set;}
        public MQuarto? Quarto {get; set;}
        public MFuncionario? Funcionario {get; set;}
        public MCliente? Cliente {get; set;}
        public DateOnly DataCheckin {get; set;}
        public DateOnly DataCheckout {get; set;}
    }
}