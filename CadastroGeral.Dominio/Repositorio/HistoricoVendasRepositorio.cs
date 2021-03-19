using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dominio.Repositorio
{
    public class HistoricoVendasRepositorio
    {
        public List<HistoricoVendas> SelectAllHistory()
        {
            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=CadastroGeral;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM HistoricoVendas";

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
                    var _HistoricoVendas = new List<HistoricoVendas>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _HistoricoVendas.Add(new HistoricoVendas()
                        {
                            IdHistorico = Convert.ToInt32(reader["IdHistorico"]),
                            TipoPagamento = reader["TipoPagamento"].ToString(),
                            IdProduto = Convert.ToInt32(reader["IdProduto"]),
                            ClienteId = Convert.ToInt32(reader["ClienteId"])

                        });
                    }
                    reader.Close();
                    return _HistoricoVendas;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
    }
}
