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
    }
}