using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class TipoServicoLavanderia
    {
        [Key]
        public int codTipoServico {get; set;}
        public string? servico {get; set;}
        public double valor {get; set;}
    }
}