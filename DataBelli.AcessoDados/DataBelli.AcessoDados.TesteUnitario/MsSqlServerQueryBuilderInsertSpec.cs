using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.TesteUnitario.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Reflection;

namespace DataBelli.AcessoDados.TesteUnitario
{
    public class MsSqlServerQueryBuilderInsertSpec
    {
        [Fact]
        public void DeveConstruirQueryInsert()
        {
            //Arrange
            var buider = new MsSqlServerQueryBuilder<PessoaMock>();

            var pessoa = new PessoaMock
            {
                DataNascimento = new DateTime(2019, 4, 3),
                Nome = "Nome Pessoa Teste"
            };

            Dictionary<string, object> parametros;

            //ACt
            var query = buider.BuildInsert(pessoa, out parametros);

            //Assert
            query.Should().Be("Insert Into Pessoa(Nome,DataNascimento)Values(@Nome,@DataNascimento)"); 
        }

        [Fact]
        public void DeveConstruirQueryInsertEMapearParametros()
        {
            //Arrange
            var buider = new MsSqlServerQueryBuilder<PessoaMock>();

            var pessoa = new PessoaMock
            {
                DataNascimento = new DateTime(2019, 4, 3),
                Nome = "Nome Pessoa Teste"
            };

            Dictionary<string, object> parametros;

            //ACt
            var query = buider.BuildInsert(pessoa, out parametros);

            //Assert
            var properties = typeof(PessoaMock)
                .GetProperties()
                .Where(p => !p.IsPrimaryKey())
                .Select(p => p.GetCustomAttribute<ColumnAttribute>().Name);
            parametros.All(p => properties.Contains(p.Key)).Should().BeTrue();
        }
        [Fact]
        public void DeveConstruirQueryInsertEMapearParametrosComValores()
        {
            //Arrange
            var buider = new MsSqlServerQueryBuilder<PessoaMock>();

            var pessoa = new PessoaMock
            {
                DataNascimento = new DateTime(2019, 4, 3),
                Nome = "Nome Pessoa Teste"
            };

            Dictionary<string, object> parametros;

            //ACt
            var query = buider.BuildInsert(pessoa, out parametros);

            //Assert
            var properties = typeof(PessoaMock)
                .GetProperties()
                .Where(p => !p.IsPrimaryKey())
                .Select(p => p.GetValue(pessoa));
            parametros.All(p => properties.Contains(p.Value)).Should().BeTrue();
        }
    }
}
