using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataBelli.AcessoDados.Construtores
{
    public static class TypeExtensions
    {
        public static bool IsPrimaryKey(this PropertyInfo property)
        {
            return property.GetCustomAttribute<PrimaryKeyAttribute>() != null;
        }
    }
}
