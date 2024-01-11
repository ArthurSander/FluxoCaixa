using FluentResults;
using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;
using FluxoCaixa.Shared.Extensions;

namespace FluxoCaixa.Application.Validators.Relatorios
{
    public class CriarRelatorioValidator : BaseValidator<CriarRelatorioDto>
    {
        public override Result Validar(CriarRelatorioDto value)
        {
            var errorMessages = new List<string>();

            if (value.IdCaixa.IsNullOrLessThanZero())
                errorMessages.Add("Id da Caixa é obrigatório.");

            if (value.TipoRelatorio == null)
                errorMessages.Add("Tipo de Relatório é obrigatório.");

            // Temporário - será removido após a implementação dos outros tipos de relatórios.
            if (value.TipoRelatorio != null && value.TipoRelatorio != TipoRelatorio.JSON)
                errorMessages.Add("Tipo de Relatório ainda não é suportado pelo sistema.");

            if (value.Data == null)
                errorMessages.Add("Data do relatório é obrigatória.");

            return obterResultado(errorMessages);
        }
    }
}
