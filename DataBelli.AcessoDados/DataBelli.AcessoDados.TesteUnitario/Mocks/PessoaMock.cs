using System;
using System.Collections.Generic;
using System.Text;
using DataBelli.AcessoDados.Construtores;

namespace DataBelli.AcessoDados.TesteUnitario.Mocks
{
    [Table("Pessoa")]
    public class PessoaMock
    {
        [ColumnAttribute("PessoaId")]
        [PrimaryKeyAttribute("PessoaId")]
        public string Id { get; set; }
        [ColumnAttribute("Nome")]
        public string Nome {get; set; }
        [ColumnAttribute("DataNascimento")]
        public DateTime DataNascimento { get; set; }
    }


}
