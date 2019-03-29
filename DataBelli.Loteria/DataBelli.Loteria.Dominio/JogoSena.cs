using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataBelli.Loteria.Dominio
{
    public class JogoSena : IJogo<ApostaSena>
    {
        #region Attributes
        private readonly List<ApostaSena> apostas = new List<ApostaSena>();
        private readonly List<int> numerosSorteados = new List<int>();
        private readonly ISorteador sorteador;
        #endregion

        #region Properts
        public ApostaSena[] Apostas => apostas.ToArray();
        public int[] NumerosSorteados => numerosSorteados.ToArray();
        #endregion


        public JogoSena(ISorteador sorteador)
        {
            this.sorteador = sorteador;
        }

        public void AdicionarApostas(ApostaSena aposta)
        {
            this.apostas.Add(aposta);
        }

        public void GerarSurpresinha(int quantidadeApostas)
        {
            var random = new Random();

            for (int i = 0; i < quantidadeApostas; i++)
            {
                var jogo = new ApostaSena();

                for (int j = 0; j < 6; j++)
                {
                    jogo.AdicionarNumero(random.Next(1, 60));
                }

                this.apostas.Add(jogo);
            }
        }

        public ApostaSena[] ObterPededores()
        {
           return this.apostas.Where(a => !a.Nuneros.All(n => this.numerosSorteados.Contains(n))).ToArray();
        }

        public ApostaSena[] ObterVencedores()
        {
            return this.apostas.Where(a => a.Nuneros.All(n => this.numerosSorteados.Contains(n))).ToArray();
        }

        public void Sortear()
        {
            this.numerosSorteados.Clear();
            this.numerosSorteados.AddRange(this.sorteador.Gerar(6, 1, 60));
            //var random =  new Random();

            //while (this.numerosSorteados.Count <  6)
            //{
            //    var numero = random.Next(1, 60); ;
            //    if (!this.numerosSorteados.Contains(numero))
            //    {
            //        this.numerosSorteados.Add(numero);
            //    }
            //}
        }
    }
}
