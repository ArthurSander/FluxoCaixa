using FluentResults;
using FluxoCaixa.DataAccess.Contexts;
using FluxoCaixa.DataAccess.Extensions;
using FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;
using FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos;
using FluxoCaixa.Domain.Repositories.Relatorios;
using FluxoCaixa.Shared.Extensions;
using FluxoCaixa.Shared.Results.Relatorios;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FluxoCaixa.DataAccess.Repositories.Relatorios
{
    public class RelatorioRepository : IRelatorioReadRepository, IRelatorioWriteRepository
    {
        protected readonly ILogger _logger;
        protected readonly FluxoCaixaDbContext _dbContext;
        protected readonly IRelatorioDataMapper _mapper;
        protected readonly ICaixaDataMapper _caixaDataMapper;

        public RelatorioRepository(ILogger logger, FluxoCaixaDbContext dbContext, IRelatorioDataMapper mapper, ICaixaDataMapper caixaDataMapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _caixaDataMapper = caixaDataMapper;
        }

        public async Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken ct = default)
        {
            var dataModel = _mapper.ToModel(relatorio, idCaixa);
            dataModel.CriadoNoBanco();

            _dbContext.Relatorios.Add(dataModel);
            await _dbContext.SaveChangesAsync(ct);

            return _mapper.ToEntity(dataModel);
        }

        public async Task<Result<Relatorio>> BuscarRelatorioComCaixaAsync(int id, CancellationToken ct = default)
        {
            var relatorioModel = await _dbContext.Relatorios.FirstOrDefaultAsync(x => x.Id == id, ct);

            if (relatorioModel == null)
                return new RelatorioNaoEncontradoResult("Não foi possível encontrar o relatório");
            
            var caixaModel = await _dbContext.Caixas.FirstOrDefaultAsync(x => x.Id == relatorioModel.IdCaixa);

            if (caixaModel == null)
                return new CaixaNaoExisteResult("Não foi possível encontrar a caixa");

            var caixa = _caixaDataMapper.ToEntity(caixaModel);

            return _mapper.ToEntity(relatorioModel, caixa);
        }

        public async Task<Result> VerificarCaixaExisteAsync(int idCaixa, CancellationToken ct = default)
        {
            var caixa = await _dbContext.Caixas.FirstOrDefaultAsync(x => x.Id == idCaixa, ct);
            if (caixa != null)
                return Result.Ok();

            return new CaixaNaoExisteResult($"Caixa {idCaixa} não existe.");
        }

        public IQueryable<Lancamento> BuscarQueryLancamentosParaRelatorio(Relatorio relatorio)
        {
            var data = relatorio.Data.ToDateTime();
            var diaSeguinte = data.AddDays(1);

            var lancamentos = from lancamento in _dbContext.Lancamentos
                              join historico in _dbContext.HistoricoLancamentos
                                on lancamento.Id equals historico.LancamentoId
                              where lancamento.CaixaId == relatorio.Caixa.Id
                              where lancamento.DataLancamento > data
                              where lancamento.DataLancamento < diaSeguinte
                              orderby lancamento.DataLancamento ascending
                              select new Lancamento(
                                  lancamento.Id,
                                  lancamento.Descricao,
                                  lancamento.Valor,
                                  historico.SaldoAnterior,
                                  historico.SaldoAtual,
                                  lancamento.Tipo,
                                  lancamento.DataLancamento
                                  );

            return lancamentos;
        }

        public async Task<double> BuscarUltimoSaldoRegistradoAsync(Relatorio relatorio, CancellationToken ct = default)
        {
            var data = relatorio.Data.ToDateTime();

            var idUltimoLancamento = await _dbContext.Lancamentos
                .Where(x => x.CaixaId == relatorio.Caixa.Id)
                .Where(x => x.DataLancamento < data)
                .OrderByDescending(x => x.DataLancamento)
                .Select(x => x.Id)
                .FirstOrDefaultAsync(ct);

            if (!idUltimoLancamento.IsGreaterThanZero())
                return 0;

            return _dbContext.HistoricoLancamentos.First(x => x.LancamentoId == idUltimoLancamento).SaldoAtual;
        }

        public async Task<Result> AtualizarRelatorioAsync(Relatorio relatorio, CancellationToken ct = default)
        {
            var model = await _dbContext.Relatorios.FirstOrDefaultAsync(x => x.Id == relatorio.Id, ct);

            if(model == null)
                return new RelatorioNaoEncontradoResult($"Relatório não existe. Id: {relatorio.Id}");

            _mapper.UpdateData(relatorio, model);
            model.AtualizadoNoBanco();

            _dbContext.Relatorios.Update(model);
            await _dbContext.SaveChangesAsync(ct);

            return Result.Ok();
        }

        public async Task<Result<Relatorio>> BuscarRelatorioAsync(int id, CancellationToken ct = default)
        {
            var relatorioModel = await _dbContext.Relatorios.FirstOrDefaultAsync(x => x.Id == id, ct);

            if (relatorioModel == null)
                return new RelatorioNaoEncontradoResult("Não foi possível encontrar o relatório");

            return _mapper.ToEntity(relatorioModel);
        }
    }
}
