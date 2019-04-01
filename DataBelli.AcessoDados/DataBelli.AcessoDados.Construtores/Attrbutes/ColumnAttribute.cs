using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.AcessoDados.Construtores
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
