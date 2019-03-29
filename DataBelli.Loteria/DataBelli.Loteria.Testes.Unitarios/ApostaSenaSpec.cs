using System;
using Xunit;
using FluentAssertions;
using DataBelli.Loteria.Dominio;
using System.Linq;

namespace DataBelli.Loteria.Testes.Unitarios
{
    public class ApostaSenaSpec
    {
        [Fact]
        public void DeveAdicionarNumero ()
        {
            // Arragnge
            var aposta = new ApostaSena();
            var numero = 10;

            // Act
            aposta.AdicionarNumero(numero);

            //Assert
            //assert.contains("teste unitario", "teste");
            //nome.Should().Be("Joao");
            //nome.Should().Be("Maria");
            //nome.Should().StartWith("J");
            aposta.Nuneros.Count().Should().Be(1);
            aposta.Nuneros.First().Should().Be(numero);
        }

    }
}
