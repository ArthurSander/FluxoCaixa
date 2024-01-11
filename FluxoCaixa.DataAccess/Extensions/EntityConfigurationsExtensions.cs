using FluxoCaixa.DataAccess.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.DataAccess.Extensions
{
    public static class EntityConfigurationsExtensions
    {
        public static void ConfigureIdentity<TEntity, TType>(this EntityTypeBuilder<TEntity> builder) 
            where TEntity : class, IDataModel<TType>
        {
            builder.HasKey(x => x.Id);
        }

        public static void ConfigureDateInfo<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity: class, IDateInfoDataModel
        {
            builder.Property(x => x.CriadoEm)
                .IsRequired();

            builder.Property(x => x.AtualizadoEm)
                .IsRequired();
        }
    }
}
