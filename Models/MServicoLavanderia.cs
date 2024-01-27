using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MServicoLavanderia
    {
        [Key]
        public int codServico {get; set;}
        public MConta? numeroConta {get; set;}
        public MTipoServicoLavanderia? codTipoServico {get; set;}
    }
}