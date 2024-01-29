using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MTipoServicoLavanderia
    {
        [Key]
        public int CodTipoServico {get; set;}
        [MaxLength(40)]
        public string? Servico {get; set;}
        public double Valor {get; set;}

        public MTipoServicoLavanderia() {

        }

        public MTipoServicoLavanderia(string servico, double valor) {
            this.Servico = servico;
            this.Valor = valor;
        }
    }
}