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
        public void GetAllEmployees()
        {
            try
            {
                Payroll_Model model = new Payroll_Model();
                using (this.connection)
                {
                    string query = @"SELECT * FROM Employee_Payroll;";
                    this.connection.Open();
                    SqlCommand command = new SqlCommand(query, this.connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ID = reader.GetInt32(0);
                            model.NAME = reader.GetString(1);
                            model.SALARY = reader.GetDouble(2);
                            model.START_DATE = reader.GetDateTime(3);
                            model.GENDER = reader.GetString(4);
                            model.PHONE = reader.GetInt32(5);
                            model.ADDRESS = reader.GetString(6);
                            model.DEPARTMENT = reader.GetString(7);
                            model.BASIC_PAY = reader.GetDouble(8);
                            model.DEDUCTIONS = reader.GetDouble(9);
                            model.TAXABLE_PAY = reader.GetDouble(10);
                            model.NET_PAY = reader.GetDouble(11);
                            Console.WriteLine("Employee ID : " + model.ID + "\nEmployee Name : " + model.NAME + "\n Salary : " + model.SALARY
                                + "\nStart Date : " + model.START_DATE + "\nGender : " + model.GENDER + "\nPhone : " + model.PHONE + "\nAddress : " + model.ADDRESS
                                + "\nDepartment : " + model.DEPARTMENT +"\nBasic Pay : "+model.BASIC_PAY+ "\nDeductions : " + model.DEDUCTIONS + "\nTax : " + model.TAXABLE_PAY
                                + "\nNetPay : " + model.NET_PAY);
                            Console.WriteLine("===========");
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
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
        public bool AddEmployee(Payroll_Model model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("ADD_EMPLOYEE", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", model.NAME);
                    command.Parameters.AddWithValue("@SALARY", model.SALARY);
                    command.Parameters.AddWithValue("@START_DATE", model.START_DATE);
                    command.Parameters.AddWithValue("@GENDER", model.GENDER);
                    command.Parameters.AddWithValue("@PHONE", model.PHONE);
                    command.Parameters.AddWithValue("@ADDRESS", model.ADDRESS);
                    command.Parameters.AddWithValue("@DEPARTMENT", model.DEPARTMENT);
                    command.Parameters.AddWithValue("@BASIC_PAY", model.BASIC_PAY);
                    command.Parameters.AddWithValue("@DEDUCTIONS", model.DEDUCTIONS);
                    command.Parameters.AddWithValue("@TAXABLE_PAY", model.TAXABLE_PAY);
                    command.Parameters.AddWithValue("@NET_PAY", model.NET_PAY);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
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
        public void UpdateValue()
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE_VALUES", this.connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { this.connection.Close(); }
        }
    }
} 