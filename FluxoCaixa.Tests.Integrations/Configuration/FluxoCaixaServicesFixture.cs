using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.UseCases.FluxoCaixa;
using FluxoCaixa.Application.Validators;
using FluxoCaixa.Application.Validators.FluxoCaixa;
using FluxoCaixa.DataAccess.Contexts;
using FluxoCaixa.DataAccess.Mappers;
using FluxoCaixa.DataAccess.Mappers.FluxoCaixa;
using FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.DataAccess.Repositories.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Events;
using FluxoCaixa.Domain.Factories.FluxoCaixa;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Repositories.FluxoCaixa;
using FluxoCaixa.Domain.Services.FluxoCaixa;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Tests.Integrations.Configuration
{
    public class FluxoCaixaServicesFixture
    {
        public Mock<IEventPublisher> MockEventPublisher = new Mock<IEventPublisher>();
        public Mock<ILogger> MockLogger = new Mock<ILogger>();

        private FluxoCaixaDbContext _dbContext;
        public FluxoCaixaDbContext DbContext
        {
            get
            {
                if(_dbContext == null)
                    _dbContext = LocalDbContextProvider.New();

                return _dbContext;
            }
        }

        public CriarCaixaUseCase NewCriarCaixaUseCase()
        {
            return new CriarCaixaUseCase(
                NewFluxoCaixaService(),
                NewCaixaApplicationMapper(),
                NewCriarCaixaValidator(),
                NewLancamentoFactory()
            );
        }

        private IFluxoCaixaService NewFluxoCaixaService()
            => new FluxoCaixaService(MockLogger.Object, NewCaixaWriteRepository(), MockEventPublisher.Object);

        private ICaixaApplicationMapper NewCaixaApplicationMapper()
            => new CaixaApplicationMapper();

        private IValidator<CriarCaixaDto> NewCriarCaixaValidator()
            => new CriarCaixaValidator();

        private ILancamentoFactory NewLancamentoFactory()
            => new DefaultLancamentoFactory(MockLogger.Object);

        private ICaixaDataMapper NewCaixaDataMapper()
            => new CaixaDataMapper();

        private IDefaultDataModelMapper<LancamentoDataModel, ILancamento> NewLancamentoDataMapper()
            => new LancamentoDataMapper(NewLancamentoFactory());

        private IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento> NewNovoLancamentoDataMapper()
            => new NovoLancamentoDataMapper();

        private ICaixaWriteRepository NewCaixaWriteRepository()
            => new CaixaRepository(
                DbContext,
                NewCaixaDataMapper(),
                NewLancamentoDataMapper(),
                NewNovoLancamentoDataMapper(),
                MockLogger.Object);
    }
}
