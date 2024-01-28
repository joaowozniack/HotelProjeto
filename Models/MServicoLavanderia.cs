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
    }
}