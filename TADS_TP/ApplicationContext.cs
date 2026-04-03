using Microsoft.EntityFrameworkCore;
using TADS_TP.Models;

namespace TADS_TP
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FabricanteModel> Fabricantes { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<AluguelModel> Alugueis { get; set; }
        public DbSet<PagamentoModel> Pagamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _= optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LocadoraDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClienteModel>()
                .HasIndex(c => c.CPF)
                .IsUnique();

            modelBuilder.Entity<VeiculoModel>()
                .HasOne(v => v.Fabricante)
                .WithMany(f => f.Veiculos)
                .HasForeignKey(v => v.FabricanteId);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Alugueis)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Veiculo)
                .WithMany(v => v.Alugueis)
                .HasForeignKey(a => a.VeiculoId);

            modelBuilder.Entity<PagamentoModel>()
                .HasOne(p => p.Aluguel)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(p => p.AluguelId);
        }
    }
}
