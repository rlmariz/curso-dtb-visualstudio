using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.Testes.Comum;
using Xunit;
using FluentAssertions;
using System;

namespace DataBelli.AcessoDados.TesteUnitario
{
    public class MsSqlServerQueryBuilderSelectSpec
    {
        [Fact]
        public void DeveConstruirQuerySelect()
        {
            //var usuarioSemTable = new UsuarioSemTable();
            var buider = new MsSqlServerQueryBuilder<PessoaMock>();
            var select = buider.BuildSelect();

            select.Should().Be("Select PessoaId,Nome,DataNascmento from Pessoa");//"Esperado: " + select
        }

        [Fact]
        public void DeveValidarTipoSemTabelaInformada()
        {
            //Arrange
            var buider = new MsSqlServerQueryBuilder<PessoaSemTabelaMock>();

            //ACt
            Action select = () => buider.BuildSelect();

            //Assert
            select.Should().Throw<Exception>();
        }

    }
}
