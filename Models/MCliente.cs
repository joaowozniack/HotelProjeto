using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MCliente
    {
        [Key]
        public int codCliente {get; set;}
        public string? nome {get; set;}
        public string? nacionalidade {get; set;}
        public string? email {get; set;}
        public string? telefone {get; set;}
    }
}