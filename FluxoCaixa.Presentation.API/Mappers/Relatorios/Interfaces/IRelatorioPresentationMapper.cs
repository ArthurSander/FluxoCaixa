using FluentResults;
using FluxoCaixa.Application.Dtos;
using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Presentation.API.Models.Relatorios.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Presentation.API.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioPresentationMapper
    {
        CriarRelatorioDto CriarRelatorioDto(CriarRelatorioRequestModel model);

        IActionResult CriarRelatorioResponse(Result<Relatorio> result);
        IActionResult CriarStatusRelatorioResponse(Result<Relatorio> result);
        IActionResult CriarDownloadRelatorioResponse(Result<FileDto> result);
    }
}
