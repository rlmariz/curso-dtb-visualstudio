using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.Loteria.Dominio
{
    public interface IAposta
    {
        Guid Identificador { get; }
        int[] Nuneros { get; }
        void AdicionarNumero(int numero);
    }
}
