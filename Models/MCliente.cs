using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProjeto
{
    public class MCliente
    {
        [Key]
        public int CodCliente {get; set;}
        [MaxLength(30)]
        public string? Nome {get; set;}
        [MaxLength(20)]
        public string? Nacionalidade {get; set;}
        [MaxLength(45)]
        public string? Email {get; set;}
        [MaxLength(15)]
        public string? Telefone {get; set;}
        public MCliente(string nome, string nacionalidade, string email, string telefone){
            this.Nome = nome;
            this.Nacionalidade = nacionalidade;
            this.Email = email;
            this.Telefone = telefone;
        }

    }
    
}