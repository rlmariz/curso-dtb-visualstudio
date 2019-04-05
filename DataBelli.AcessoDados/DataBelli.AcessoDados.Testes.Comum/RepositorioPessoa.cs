using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataBelli.AcessoDados.Testes.Comum
{
    public class RepositorioPessoa
    {
        private readonly string connectionString;

        public RepositorioPessoa(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public PessoaMock Get(string nome)
        {
            using(var conn = new SqlConnection(this.connectionString))
            {
                using(var command = new SqlCommand($"Select id, nome, datanascimento from pessoa where nome = '{nome}'"))
                {
                    conn.Open();

                    command.Connection = conn;

                    var reader = command.ExecuteReader();
                    var pessoas = new List<PessoaMock>();

                    if (reader.Read())
                    {
                        return new PessoaMock
                        {
                            DataNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento")),
                            Nome = reader["nome"].ToString(),
                            Id = reader.GetInt32(reader.GetOrdinal("Id"))
                        };
                    }
                }
            }

            return null;
        }
    }
}
