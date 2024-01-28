using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MConta 
    {
        [Key]
        public int NumeroConta {get; set;}
        public MCliente? Cliente {get; set;}
        public double ValorTotal {get; set;}
    }
}