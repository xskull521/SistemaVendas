using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SistemaVendas.Dominio.Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> SelectAllClients()
        {
            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=CadastroGeral;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM Cliente";

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
                    var _Cliente = new List<Cliente>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Cliente.Add(new Cliente()
                        {
                            ClienteId = Convert.ToInt32(reader["ClienteId"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Endereco = reader["Nome"].ToString(),
                            Celular = Convert.ToInt32(reader["Celular"]),
                            Cpf = Convert.ToInt32(reader["Cpf"])

                        });
                    }
                    reader.Close();
                    return _Cliente;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

        public void AddEmployee(Cliente employee)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  


            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=CadastroGeral;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO CLiente (Nome,Email,Endereco,Celular,Cpf) Values (@Nome,@Email,@Endereco,@Celular,@Cpf)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@Nome", employee.Nome);
            sqlCmd.Parameters.AddWithValue("@Email", employee.Email);
            sqlCmd.Parameters.AddWithValue("@Endereco", employee.Endereco);
            sqlCmd.Parameters.AddWithValue("@Celular", employee.Celular);
            sqlCmd.Parameters.AddWithValue("@Cpf", employee.Cpf);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public void DeleteEmployeeByID(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=CadastroGeral;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblEmployee where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

    }
}



