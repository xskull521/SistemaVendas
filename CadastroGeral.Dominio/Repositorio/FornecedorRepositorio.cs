using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dominio.Repositorio
{
    public class FornecedorRepositorio
    {
        public List<Fornecedor> SelectAllProvider()
        {
            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=CadastroGeral;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM Fornecedor";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);


                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    var _Fornecedor = new List<Fornecedor>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Fornecedor.Add(new Fornecedor()
                        {
                            IdFornecedor = Convert.ToInt32(reader["IdFornecedor"]),
                            Nome = reader["Nome"].ToString(),
                            Endereço = reader["Endereço"].ToString(),
                            Cnpj = Convert.ToInt32(reader[" Cnpj"])

                        });
                    }
                    reader.Close();
                    return _Fornecedor;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
    }
}