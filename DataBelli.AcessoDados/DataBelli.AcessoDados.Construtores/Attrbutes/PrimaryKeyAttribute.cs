using System;

namespace DataBelli.AcessoDados.Construtores
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
