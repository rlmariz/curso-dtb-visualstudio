using System;
using System.Collections.Generic;
using System.Text;
using DataBelli.AcessoDados.Construtores;

namespace DataBelli.AcessoDados.TesteUnitario.Mocks
{
    [TableAttribute("Pessoa")]
    public class PessoaMock
    {
        [ColumnAttribute("PessoaId")]
        public string Id { get; set; }
        [ColumnAttribute("Nome")]
        public string Nome {get; set; }
        [ColumnAttribute("DataNascmento")]
        public DateTime DataNascimento { get; set; }
    }


}
