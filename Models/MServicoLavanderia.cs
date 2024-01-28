using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProjeto
{
    public class MServicoLavanderia
    {
        [Key]
        public int CodServico {get; set;}
        public MConta? NumeroConta {get; set;}
        public MTipoServicoLavanderia? TipoServico {get; set;}

        public MServicoLavanderia() {

        }

        public MServicoLavanderia(MConta numeroConta, MTipoServicoLavanderia tipoServico) {
            this.NumeroConta = numeroConta;
            this.TipoServico = tipoServico;
        }
    }
}