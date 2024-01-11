using FluxoCaixa.DataAccess.Models.Interfaces;

namespace FluxoCaixa.DataAccess.Extensions
{
    public static class DataModelExtensions
    {
        public static void CriadoNoBanco(this IDateInfoDataModel model)
        {
            model.CriadoEm = DateTime.UtcNow;
            model.AtualizadoEm = DateTime.UtcNow;
        }

        public static void AtualizadoNoBanco(this IDateInfoDataModel model)
        {
            model.AtualizadoEm = DateTime.UtcNow;
        }
    }
}
