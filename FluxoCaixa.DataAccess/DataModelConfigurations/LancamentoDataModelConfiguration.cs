using FluxoCaixa.DataAccess.Extensions;
using FluxoCaixa.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.DataAccess.DataModelConfigurations
{
    public class LancamentoDataModelConfiguration : IEntityTypeConfiguration<LancamentoDataModel>
    {
        public void Configure(EntityTypeBuilder<LancamentoDataModel> builder)
        {
            builder.ToTable("lancamentos");

            builder.ConfigureIdentity<LancamentoDataModel, int>();
            builder.ConfigureDateInfo();

            builder.Property(x => x.Descricao)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.DataLancamento)
                .IsRequired();
        }
    }
}
