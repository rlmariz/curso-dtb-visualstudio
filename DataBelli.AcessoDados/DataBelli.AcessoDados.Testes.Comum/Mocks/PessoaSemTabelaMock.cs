using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBelli.AcessoDados.Testes.Comum
{
    public class PessoaSemTabelaMock
    {
        [ColumnAttribute("PessoaId")]
        public string Id { get; set; }
        [ColumnAttribute("Nome")]
        public string Nome { get; set; }
        [ColumnAttribute("DataNascmento")]
        public DateTime DataNascimento { get; set; }
    }

}
