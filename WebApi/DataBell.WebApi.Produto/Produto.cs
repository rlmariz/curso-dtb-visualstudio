using DataBelli.AcessoDados.Construtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBell.WebApi.Produto
{
    [Table("Produtos")]
    public class Produto
    {
        [ColumnAttribute("Id")]
        //[PrimaryKeyAttribute("Id")]
        public Guid Id { get; set; }
        [ColumnAttribute("Nome")]
        public String Nome { get; set; }
        [ColumnAttribute("Categoria")]
        public String Categoria { get; set; }
        [ColumnAttribute("Cor")]
        public String Cor { get; set; }
        [ColumnAttribute("Origem")]
        public String Origem { get; set; }
    }
}
