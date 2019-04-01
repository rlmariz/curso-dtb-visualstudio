using System;
using System.Collections.Generic;
using System.Text;

namespace DataBelli.AcessoDados.Construtores
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
