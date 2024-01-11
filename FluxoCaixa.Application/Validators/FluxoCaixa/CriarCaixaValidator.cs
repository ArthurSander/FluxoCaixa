using FluentResults;
using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Shared.Extensions;

namespace FluxoCaixa.Application.Validators.FluxoCaixa
{
    public class CriarCaixaValidator : BaseValidator<CriarCaixaDto>
    {
        public override Result Validar(CriarCaixaDto value)
        {
            var errorMessages = new List<string>();
            
            if (string.IsNullOrWhiteSpace(value.Nome))
                errorMessages.Add("Nome do Caixa é obrigatório.");

            if (value.SaldoInicial.IsNullOrLessThanZero())
                errorMessages.Add("Saldo inicial deve ser maior ou igual a 0");

            return obterResultado(errorMessages);
        }
    }
}
