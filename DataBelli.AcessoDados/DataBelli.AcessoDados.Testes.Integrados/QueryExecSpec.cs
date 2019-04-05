using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.Executores;
using DataBelli.AcessoDados.Testes.Comum;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataBelli.AcessoDados.Testes.Integrados
{
    public class QueryExecSpec : IClassFixture<DbProviderFixture>
    {
        private readonly DbProviderFixture fixture;

        public QueryExecSpec(DbProviderFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void DeveInserirInstanciaNoSqlServer()
        {

            //Arrange
            var builder = new MsSqlServerQueryBuilder<PessoaMock>();
            var queryExec = new QueryExec<PessoaMock>(builder);
            var nome = Guid.NewGuid().ToString();

            var pessoa = new PessoaMock
            {
                Nome = nome,
                DataNascimento = new DateTime(2018, 12, 05)
            };

            //ACt
            queryExec.Insert(pessoa);

            //Assert
            var repositocio = new RepositorioPessoa(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123");
            var pessoaCriada = repositocio.Get(nome);
            pessoaCriada.Should().NotBeNull();
            pessoaCriada?.Id.Should().BePositive();
            pessoaCriada?.Nome.Should().Be(pessoa.Nome);
            pessoaCriada?.DataNascimento.Should().Be(pessoa.DataNascimento);

        }

        [Fact]
        public void DeveSelecionarInstanciasNoSqlServer()
        {

            //Arrange
            var builder = new MsSqlServerQueryBuilder<PessoaMock>();
            var queryExec = new QueryExec<PessoaMock>(builder);
            var pessoas = new List<PessoaMock>();
            var where = new StringBuilder();

            //ACt
            where.Append(" where nome in (");

            for (int i = 0; i < 10; i++)
            {
                var pessoa = new PessoaMock
                {
                    Nome = Guid.NewGuid().ToString(),
                    DataNascimento = new DateTime(2018, 12, 05)
                };
                queryExec.Insert(pessoa);
                pessoas.Add(pessoa);
                where.Append($"'{pessoa.Nome}'");

                if (i != 9)
                {
                    where.Append(",");
                }
            }

            where.Append(")");

            var pessoasSelect = queryExec.Select(where.ToString());

            //Assert
            pessoasSelect.Count().Should().Be(10);
            //foreach (var pessoa in pessoas)
            //{
            // }

            //var repositocio = new RepositorioPessoa(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123");
            //var pessoaCriada = repositocio.Get(nome);
            //pessoaCriada.Should().NotBeNull();
            //pessoaCriada?.Id.Should().BePositive();
            //pessoaCriada?.Nome.Should().Be(pessoa.Nome);
            //pessoaCriada?.DataNascimento.Should().Be(pessoa.DataNascimento);

        }
    }
}
