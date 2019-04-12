using DataBelli.AcessoDados.Executores;
using DataBelli.AcessoDados.Construtores;
using System;
using Xunit;
using A = DataBell.WebApi.Produto;
using FluentAssertions;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataBelli.WebApi.Produto.Testes.Unitarios
{
    public class ProdutoControllerSpec
    {
        [Fact]
        public void DeveInserirProduto()
        {
            DbProviderFactories.RegisterFactory("MsSqlServer", SqlClientFactory.Instance);

            var idProduto = Guid.NewGuid();
            var queryExec = new QueryExec<A.Produto>(new MsSqlServerQueryBuilder<A.Produto>());
            var produto = new A.Produto()
            {
                Id = idProduto,
                Nome = "Produto Teste",
                Categoria = "Teste Inclusão",
                Origem = "Produção Interna",
                Cor = "Verde"
            };
            queryExec.Insert(produto);

            var produtoInserido = queryExec.Select($" where Id = '{idProduto.ToString()}'");
            produtoInserido.Should().NotBeNull();
        }
    }
}
