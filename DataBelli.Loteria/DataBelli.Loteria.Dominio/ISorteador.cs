using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.Loteria.Dominio
{
    public interface ISorteador
    {
        int[] Gerar(int quantidade, int numeroMinimo, int NumeroMaximo);
    }

    public class Sorteador : ISorteador
    {
        public int[] Gerar(int quantidade, int numeroMinimo, int NumeroMaximo)
        {
            var random = new Random();
            var numeros = new List<int>();
            while (numeros.Count < quantidade)
            {
                var numero = random.Next(numeroMinimo, NumeroMaximo);

                if (!numeros.Contains(numero))
                {
                    numeros.Add(numero);
                }
            }

            return numeros.ToArray();
        }
    }
}
