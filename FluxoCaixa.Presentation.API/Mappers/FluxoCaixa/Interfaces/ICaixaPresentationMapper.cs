using FluentResults;
using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Presentation.API.Models.FluxoCaixa.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Presentation.API.Mappers.FluxoCaixa.Interfaces
{
    public interface ICaixaPresentationMapper
    {
        CriarCaixaDto CriarCaixaDto(CriarCaixaRequestModel request);
        AdicionarLancamentoDto AdicionarLancamentoDto(AdicionarLancamentoRequestModel requestModel);

        ObjectResult CriarCaixaResponse(Result<Caixa> result);
        ObjectResult AdicionarLancamentoResponse(Result<Caixa> result);
        ObjectResult ConsultarSaldoResponse(Result<ConsultarSaldoDto> result);
    }
}
