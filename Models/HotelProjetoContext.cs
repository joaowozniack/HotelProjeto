using Microsoft.EntityFrameworkCore;

namespace HotelProjeto
{
    public class HotelProjetoContext : DbContext
    {
        public DbSet<MCliente> MCliente {get; set;} = null!;
        public DbSet<MCargo> MCargo {get; set;} = null!;
        public DbSet<MFuncionario> MFuncionario {get; set;} = null!;
        public DbSet<MTipoQuarto> MTipoQuarto {get; set;} = null!;
        public DbSet<MQuarto> MQuarto {get; set;} = null!;
        public DbSet<MReserva> MReserva {get; set;} = null!;
        public DbSet<MConta> MConta {get; set;} = null!;
        public DbSet<MFormaPagamento> MFormaPagamento {get; set;} = null!;
        public DbSet<MPagamento> MPagamento {get; set;} = null!;
        public DbSet<MEndereco> MEndereco {get; set;} = null!;
        public DbSet<MFilial> MFilial {get; set;} = null!;
        public DbSet<MConsumoRestauranteFrigobar> MConsumoRestauranteFrigobar {get; set;} = null!;
        public DbSet<MTipoServicoLavanderia> MTipoServicoLavanderia {get; set;} = null!;
        public DbSet<MServicoLavanderia> MServicoLavanderia {get; set;} = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=HotelProjeto;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}