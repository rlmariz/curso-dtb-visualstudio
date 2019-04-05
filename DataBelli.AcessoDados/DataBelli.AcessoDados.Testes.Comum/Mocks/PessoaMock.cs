using System;
using System.Collections.Generic;
using System.Text;
using DataBelli.AcessoDados.Construtores;

namespace DataBelli.AcessoDados.Testes.Comum
{
    [Table("Pessoa")]
    public class PessoaMock
    {
        [ColumnAttribute("Id")]
        [PrimaryKeyAttribute("Id")]
        public int Id { get; set; }
        [ColumnAttribute("Nome")]
        public string Nome {get; set; }
        [ColumnAttribute("DataNascimento")]
        public Nullable<DateTime> DataNascimento { get; set; }
    }


}
