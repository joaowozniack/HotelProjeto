using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class ServicoLavanderia
    {
        [Key]
        public int codServico {get; set;}
        public Conta? numeroConta {get; set;}
        public TipoServicoLavanderia? codTipoServico {get; set;}
    }
}