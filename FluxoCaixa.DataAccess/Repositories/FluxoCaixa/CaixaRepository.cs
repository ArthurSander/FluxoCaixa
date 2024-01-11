using FluentResults;
using FluxoCaixa.DataAccess.Extensions;
using FluxoCaixa.DataAccess.Mappers;
using FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Repositories.FluxoCaixa;
using FluxoCaixa.Shared.Results.Generic;
using FluxoCaixa.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluxoCaixa.Shared.Logs;
using FluxoCaixa.DataAccess.Contexts;

namespace FluxoCaixa.DataAccess.Repositories.FluxoCaixa
{
    // Caso existam fontes diferentes para escrita e leitura no futuro, é possível implementar cada um dos repositórios em classes diferentes
    public class CaixaRepository : ICaixaWriteRepository, ICaixaReadRepository
    {
        protected readonly FluxoCaixaDbContext _context;
        protected readonly ICaixaDataMapper _caixaMapper;
        protected readonly IDefaultDataModelMapper<LancamentoDataModel, ILancamento> _lancamentoMapper;
        protected readonly IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento> _novoLancamentoMapper;
        protected readonly ILogger _logger;

        public CaixaRepository(FluxoCaixaDbContext context, ICaixaDataMapper caixaMapper, 
            IDefaultDataModelMapper<LancamentoDataModel, ILancamento> lancamentoMapper, 
            IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento> novoLancamentoMapper, ILogger logger)
        {
            _context = context;
            _caixaMapper = caixaMapper;
            _lancamentoMapper = lancamentoMapper;
            _novoLancamentoMapper = novoLancamentoMapper;
            _logger = logger;
        }

        public async Task<Result<int>> AdicionarLancamentoAsync(int caixaId, ILancamento lancamento, NovoLancamento eventoLancamento, CancellationToken ct = default)
        {
            var lancamentoModel = _lancamentoMapper.ToModel(lancamento);
            var eventoLancamentoModel = _novoLancamentoMapper.ToModel(eventoLancamento);

            lancamentoModel.CaixaId = caixaId;
            lancamentoModel.CriadoNoBanco();

            _context.Lancamentos.Add(lancamentoModel);
            await _context.SaveChangesAsync(ct);

            eventoLancamentoModel.LancamentoId = lancamentoModel.Id;
            _context.HistoricoLancamentos.Add(eventoLancamentoModel);
            await _context.SaveChangesAsync(ct);


            return lancamentoModel.Id;
        }

        public async Task<Result<Caixa>> ConsultarAsync(int id, CancellationToken ct = default)
        {
            var caixaModel = await _context.Caixas.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (caixaModel == null)
                return new EmptyResult<Caixa>();

            var ultimoLancamentoId = await _context.Lancamentos.Where(x => x.CaixaId == id).OrderByDescending(x => x.CriadoEm).Select(x => x.Id).FirstOrDefaultAsync(ct);
            if (!ultimoLancamentoId.IsGreaterThanZero())
                return _caixaMapper.ToEntity(caixaModel, 0);

            var ultimoRegistroHistorico = await _context.HistoricoLancamentos.FirstOrDefaultAsync(x => x.LancamentoId == ultimoLancamentoId, ct);
            if(ultimoRegistroHistorico == null)
            {
                _logger.Warning($"{LogVariables.ClassAndMethodName} Não foi possível obter o histórico do lançamento. " +
                    $"Id Lancamento: {LogVariables.LancamentoId} | Id Caixa: {LogVariables.CaixaId}",
                    nameof(CaixaRepository), nameof(ConsultarAsync), ultimoLancamentoId, id);

                return _caixaMapper.ToEntity(caixaModel, 0);
            }

            return _caixaMapper.ToEntity(caixaModel, ultimoRegistroHistorico.SaldoAtual);
        }

        public async Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default)
        {
            var caixaModel = _caixaMapper.ToModel(caixa);
            caixaModel.CriadoNoBanco();

            _context.Caixas.Add(caixaModel);
            await _context.SaveChangesAsync(ct);

            return _caixaMapper.ToEntity(caixaModel, caixa.Saldo.Valor);
        }
    }
}
