using FluxoCaixa.Application.UseCases.Relatorios.Interfaces;
using FluxoCaixa.Presentation.API.Mappers.Relatorios.Interfaces;
using FluxoCaixa.Presentation.API.Models.Relatorios.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Presentation.API.Controllers
{
    [Route("api/relatorios")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioPresentationMapper _mapper;

        public RelatoriosController(IRelatorioPresentationMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CriarRelatorio(
            [FromBody] CriarRelatorioRequestModel model,
            [FromServices] ICriarRelatorioUseCase useCase,
            CancellationToken cancellationToken = default)
        {
            var dto = _mapper.CriarRelatorioDto(model);

            var result = await useCase.ExecutarAsync(dto, cancellationToken);

            return _mapper.CriarRelatorioResponse(result);
        }

        [HttpGet("{id_relatorio}/status")]
        public async Task<IActionResult> ObterStatus(
            [FromRoute] int id_relatorio,
            [FromServices] IConsultarStatusRelatorioUseCase useCase,
            CancellationToken ct)
        {
            var result = await useCase.ExecutarAsync(id_relatorio, ct);
            return _mapper.CriarStatusRelatorioResponse(result);
        }

        [HttpGet("{id_relatorio}/download")]
        public async Task<IActionResult> DownloadRelatorio(
            [FromRoute] int id_relatorio,
            [FromServices] IDownloadRelatorioUseCase useCase,
            CancellationToken ct)
        {
            var result = await useCase.ExecutarAsync(id_relatorio, ct);
            return _mapper.CriarDownloadRelatorioResponse(result);
        }
    }
}
