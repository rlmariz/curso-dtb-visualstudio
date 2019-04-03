using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.AcessoDados.Executores
{
    public interface IQueryExec<T>
    {
        void Insert(T instance);

        IEnumerable<T> Select(string where);
    }
}
