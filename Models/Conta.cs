using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class Conta 
    {
        [Key]
        public int numeroConta {get; set;}
        public Cliente? codCliente {get; set;}
        public double valorTotal {get; set;}
    }
}