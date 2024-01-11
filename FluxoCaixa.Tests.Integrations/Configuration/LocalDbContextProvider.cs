using FluxoCaixa.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Tests.Integrations.Configuration
{
    public class LocalDbContextProvider
    {
        public static FluxoCaixaDbContext New()
        {
            var options = new DbContextOptionsBuilder<FluxoCaixaDbContext>()
                .UseInMemoryDatabase(databaseName: "FluxoCaixaDb")
                .Options;

            return new FluxoCaixaDbContext(options);
        }
    }
}
