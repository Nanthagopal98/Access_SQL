using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Access_SQL_ADO.NET
{
    public class Employee_Repo
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Payroll_Service;";
        SqlConnection connection = new SqlConnection(connectionString);
        public DataSet GetPayroll()
        {
            try
            {
                DataSet data = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();                    
                    SqlDataAdapter adapter = new SqlDataAdapter("CONNECTIVITY", this.connection);
                    adapter.Fill(data);
                    this.connection.Close();
                    Console.WriteLine("Connection Established");
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }       
    }
}