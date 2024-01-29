using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MConta 
    {
        [Key]
        public int NumeroConta {get; set;}
        public MCliente Cliente {get; set;}
        public double ValorTotal {get; set;}

        public MConta() {

        }

        public MConta(MCliente cliente, double valorTotal){
            this.Cliente = cliente;
            this.ValorTotal = valorTotal;
        }
    }
}