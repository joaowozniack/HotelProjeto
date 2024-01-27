using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MConta 
    {
        [Key]
        public int numeroConta {get; set;}
        public MCliente? codCliente {get; set;}
        public double valorTotal {get; set;}
    }
}