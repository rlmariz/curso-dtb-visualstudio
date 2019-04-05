using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.Executores;
using DataBelli.AcessoDados.Testes.Comum;
using System;
using Xunit;
using FluentAssertions;

namespace DataBelli.AcessoDados.Testes.Integrados
{
    public class QueryExecSpec
    {
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
            }
            ;
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
    }
}
