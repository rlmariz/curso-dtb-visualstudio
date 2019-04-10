using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBelli.WebApi
{
    public class Pedido
    {
        public Pedido()
        {
            //this.Id = Guid.NewGuid().ToString();
        }
        public Guid Id { get; set; }
    }
    public class Repositocio : IRepositorio
    {
        public Pedido Get(Guid id)
        {
           return new Pedido()
           {
               Id = id
           };
        }
    }
}
