using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.TesteUnitario.Mocks;
using Xunit;
using FluentAssertions;
using System;

namespace DataBelli.AcessoDados.TesteUnitario
{
    public class MsSqlServerQueryBuilderSpec
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
