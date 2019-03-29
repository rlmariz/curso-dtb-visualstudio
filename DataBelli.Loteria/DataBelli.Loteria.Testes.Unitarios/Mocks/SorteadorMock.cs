using DataBelli.Loteria.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.Loteria.Testes.Unitarios.Mocks
{
    public class SorteadorMock : ISorteador
    {
        public int[] Gerar(int quantidade, int numeroMinimo, int NumeroMaximo)
        {
            return new int[] { 1, 2, 3, 4, 5, 6 };
        }
    }
}
