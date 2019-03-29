using System;
using System.Data.SqlClient;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var connection = new SqlConnection(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123"))
            //{

            //    using (var command = new SqlCommand("Select Id, Nome, DataNascimento From Usuario", connection))
            //    { 

            //        connection.Open();

            //        var reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            Console.WriteLine(reader["Id"]);
            //            Console.WriteLine(reader["Nome"]);
            //            Console.WriteLine(reader.GetDateTime(reader.GetOrdinal("DataNascimento")).ToString("dd/MM/yyyy"));
            //            Console.WriteLine("-----------------------------------------------------------");
            //        }

            //        connection.Close();

            //        Console.Read();
            //    }
            //}

            //var nome = "Maria";
            //var dataNascimento = DateTime.Now.AddYears(-21);
            //var endereco = "Rua A";

            //using (var connection = new SqlConnection(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123"))
            //{

            //    using (var command = new SqlCommand($"Insert Into Usuario (Nome, DataNascimento, Endereco) values (@Nome, @DataNascimento, @Endereco)", connection))
            //    {

            //        command.Parameters.AddWithValue("Nome", nome);
            //        command.Parameters.AddWithValue("DataNascimento", dataNascimento);
            //        command.Parameters.AddWithValue("Endereco", endereco);

            //        connection.Open();

            //        var linhas = command.ExecuteNonQuery();

            //        Console.WriteLine($"Registros afetados: {linhas}");

            //        connection.Close();

            //        Console.Read();
            //    }
            //}


            using (var connection = new SqlConnection(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123"))
            {

                using (var command = new SqlCommand("Select Id, Nome, DataNascimento From Usuario Where Id =  @Id", connection))
                {

                    var id = default(int);

                    Console.WriteLine("Entre com o número o Id:");

                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Id inválido!");
                    }

                    command.Parameters.AddWithValue("id", id);

                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine(reader["Id"]);
                        Console.WriteLine(reader["Nome"]);
                        Console.WriteLine(reader.GetDateTime(reader.GetOrdinal("DataNascimento")).ToString("dd/MM/yyyy"));
                        Console.WriteLine("-----------------------------------------------------------");
                    }

                    connection.Close();

                    Console.Read();
                }
            }


            /*
            var connection = new SqlConnection(@"Data Source = 192.168.10.2\SQLEXPRESS; Initial Catalog = CursoVisualStudio; Persist Security Info = True; User ID = sa; Password = 123");

            var command = new SqlCommand("Select Id, Nome, DataNascimento From Usuario", connection);

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["Id"]);
                Console.WriteLine(reader["Nome"]);
                Console.WriteLine(reader.GetDateTime(reader.GetOrdinal("DataNascimento")).ToString("dd/MM/yyyy"));
                Console.WriteLine("-----------------------------------------------------------");
            }

            connection.Close();

            Console.Read();
            */
        }
    }
}
