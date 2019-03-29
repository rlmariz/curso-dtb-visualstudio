using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.Loteria.Dominio
{
    public class ApostaSena : IAposta
    {

        #region Attributes

        private readonly List<int> numeros = new List<int>();

        #endregion

        public Guid Identificador { get; }

        public int[] Nuneros => this.numeros.ToArray();

        public ApostaSena()
        {
            this.Identificador = Guid.NewGuid();
        }

        public void AdicionarNumero(int numero)
        {
            this.numeros.Add(numero);
        }

        public void AdicionarNumeros(params int[] numeros)
        {
            this.numeros.AddRange(numeros);
        }
    }
}
