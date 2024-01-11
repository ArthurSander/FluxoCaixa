using FluxoCaixa.DataAccess.DataModelConfigurations;
using FluxoCaixa.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.DataAccess.Contexts
{
    public class FluxoCaixaDbContext : DbContext
    {
        public FluxoCaixaDbContext(DbContextOptions<FluxoCaixaDbContext> options) : base(options) { }

        public DbSet<CaixaDataModel> Caixas { get; set; }
        public DbSet<LancamentoDataModel> Lancamentos { get; set; }
        public DbSet<RelatorioDataModel> Relatorios { get; set; }

        // Pode existir um event storage dedicado no futuro, elinando a tabela do banco relacional principal.
        public DbSet<NovoLancamentoDataModel> HistoricoLancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CaixaDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new NovoLancamentoDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new RelatorioDataModelConfiguration());
        }
    }
}
