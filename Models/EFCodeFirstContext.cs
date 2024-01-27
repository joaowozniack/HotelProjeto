using Microsoft.EntityFrameworkCore;

namespace HotelProjeto
{
    public class EFCodeFirstContext : DbContext
    {
        public DbSet<Cliente> Cliente {get; set;} = null!;
        public DbSet<Cargo> Cargo {get; set;} = null!;
        public DbSet<Funcionario> Funcionario {get; set;} = null!;
        public DbSet<TipoQuarto> TipoQuarto {get; set;} = null!;
        public DbSet<Quarto> Quarto {get; set;} = null!;
        public DbSet<Reserva> Reserva {get; set;} = null!;
        public DbSet<Conta> Conta {get; set;} = null!;
        public DbSet<FormaPagamento> FormaPagamento {get; set;} = null!;
        public DbSet<Pagamento> Pagamento {get; set;} = null!;
        public DbSet<Endereco> Endereco {get; set;} = null!;
        public DbSet<Filial> Filial {get; set;} = null!;
        public DbSet<ConsumoRestauranteFrigobar> ConsumoRestauranteFrigobar {get; set;} = null!;
        public DbSet<TipoServicoLavanderia> TipoServicoLavanderia {get; set;} = null!;
        public DbSet<ServicoLavanderia> ServicoLavanderia {get; set;} = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=HotelCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}