using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBelli.WebApi.Models
{
    public class PedidoModel
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeItens { get; set; }
        public string Obsevacoes { get; set; }
    }
}
