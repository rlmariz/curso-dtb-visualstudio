using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DataBelli.Loteria.Dominio;
using System.Linq;
using DataBelli.Loteria.Testes.Unitarios.Mocks;

namespace DataBelli.Loteria.Testes.Unitarios
{

    public class JogoSenaSpec
    {
        [Fact]
        public void DeveSortearNumerosDistintos()
        {
            // Arragnge
            var jogo = new JogoSena(new Sorteador());

            // Act
            jogo.Sortear();

            //Assert
            jogo.NumerosSorteados.Distinct().Count().Should().Be(6);
        }

        [Fact]
        public void DeveSortearNumerosCompreendidosPeloRangeDe1a60()
        {
            // Arragnge
            var jogo = new JogoSena(new Sorteador());

            // Act
            jogo.Sortear();

            //Assert
            jogo.NumerosSorteados.All(n => n >= 1 && n <= 60).Should().BeTrue();
            jogo.NumerosSorteados.Count(n => n >= 1 && n <= 60).Should().Be(6);
        }

        [Fact]
        public void DeveIdentifcarVencedoresDoSorteio()
        {
            // Arragnge
            var jogo = new JogoSena(new SorteadorMock());
            ApostaSena aposta = null;

            // Act
            aposta = new ApostaSena();
            aposta.AdicionarNumeros(1, 2, 3, 4, 5, 6 );
            jogo.AdicionarApostas(aposta);

            aposta = new ApostaSena();
            aposta.AdicionarNumeros(1, 6, 5, 2, 4, 3);
            jogo.AdicionarApostas(aposta);

            jogo.GerarSurpresinha(5000);

            //for (int i = 0; i < 5; i++)
            //{
            //    aposta = new ApostaSena();

            //    for (int j = 1; j <= 6; j++)
            //    {
            //        aposta.AdicionarNumero(j + (6 * i));
            //    }

            //    jogo.AdicionarApostas(aposta);
            //}

            jogo.Sortear();

            //Assert
            jogo.ObterVencedores().Count().Should().Be(2, "Quantidade de vencedor errada!");
        }
    }
}
