using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MTipoServicoLavanderia
    {
        [Key]
        public int codTipoServico {get; set;}
        public string? servico {get; set;}
        public double valor {get; set;}
    }
}