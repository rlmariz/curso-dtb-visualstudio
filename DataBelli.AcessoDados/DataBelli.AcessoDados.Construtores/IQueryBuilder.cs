﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.AcessoDados.Construtores
{
    public interface IQueryBuilder<T>
    {
        string BuildSelect(string where = null);
        string BuildInsert(T instance, out Dictionary<string, object> parametros);
        string BuildDelete(T instance);
        string BuildUpdate(T instance);
    }
}
