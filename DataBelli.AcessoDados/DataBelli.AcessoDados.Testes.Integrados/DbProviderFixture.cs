using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DataBelli.AcessoDados.Testes.Integrados
{
    public class DbProviderFixture : IDisposable
    {
        public DbProviderFixture()
        {
            DbProviderFactories.RegisterFactory("MsSqlServer", SqlClientFactory.Instance);
        }


        public void Dispose()
        {
        }
    }
}
