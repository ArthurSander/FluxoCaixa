using FluxoCaixa.DataAccess.Extensions;
using FluxoCaixa.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.DataAccess.DataModelConfigurations
{
    internal class RelatorioDataModelConfiguration : IEntityTypeConfiguration<RelatorioDataModel>
    {
        public void Configure(EntityTypeBuilder<RelatorioDataModel> builder)
        {
            builder.ToTable("relatorios");

            builder.ConfigureIdentity<RelatorioDataModel, int>();
            builder.ConfigureDateInfo();

            builder.Property(x => x.Data)
                .IsRequired();
            
            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(x => x.Caixa)
                .WithMany()
                .HasForeignKey(x => x.IdCaixa)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
