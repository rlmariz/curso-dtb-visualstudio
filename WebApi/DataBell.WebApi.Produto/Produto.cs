using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBell.WebApi.Produto
{
    public class Produto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public String Cor { get; set; }
        public String Origem { get; set; }
    }
}
