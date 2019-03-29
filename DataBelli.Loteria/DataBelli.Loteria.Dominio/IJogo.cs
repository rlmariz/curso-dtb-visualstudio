using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.Loteria.Dominio
{
    interface IJogo<T> where T : IAposta
    {
        T[] Apostas { get; }
        int[] NumerosSorteados { get; }

        void AdicionarApostas(T aposta);
        void GerarSurpresinha(int quantidadeApostas);
        void Sortear();
        T[] ObterVencedores();
        T[] ObterPededores();
    }
}
