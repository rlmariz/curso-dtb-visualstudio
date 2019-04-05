using System;
using System.Collections.Generic;
using DataBelli.AcessoDados.Construtores;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace DataBelli.AcessoDados.Executores
{
    public class QueryExec<T> : IQueryExec<T>
    {
        private readonly IQueryBuilder<T> builder;
        private readonly DbProviderFactory factory;

        public QueryExec(IQueryBuilder<T> builder)
        {
            DbProviderFactories.RegisterFactory("MsSqlServer", SqlClientFactory.Instance);
            this.factory = DbProviderFactories.GetFactory("MsSqlServer");

            this.builder = builder;
        }

        public void Insert(T instance)
        {
            var conn = this.factory.CreateConnection();

            conn.ConnectionString = @"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123";

            var command = conn.CreateCommand();

            conn.Open();

            Dictionary<string, object>  parametros;

            command.CommandText = builder.BuildInsert(instance, out parametros);

            foreach (var parametro in parametros)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = parametro.Key;
                parameter.Value = parametro.Value;

                command.Parameters.Add(parameter);
                //var i = command.Parameters.Add(parametro.Key);
                //command.Parameters[i].Value = parametro.Value;
            }

            var transaction = conn.BeginTransaction();

            command.ExecuteNonQuery();

            transaction.Commit();

            conn.Close();
        }

        public IEnumerable<T> Select(string where)
        {
            throw new NotImplementedException();
        }
    }
}
