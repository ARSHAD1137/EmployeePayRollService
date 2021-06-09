using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService1
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service16;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);

                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                            System.Console.WriteLine(employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    //var qury=values()
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    //command.Parameters.AddWithValue("@City", model.City);
                    //command.Parameters.AddWithValue("@Country", model.Country);
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
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public bool UpdateEmployeeDetails(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    SqlCommand update = new SqlCommand("SpUpdateEmployeeDetails", this.connection);
                    update.CommandType = System.Data.CommandType.StoredProcedure;
                    update.Parameters.AddWithValue("@id", model.EmployeeID);
                    update.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                    this.connection.Open();
                    var result = update.ExecuteNonQuery();
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
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public bool ReterieveData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel_1 = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll where start between 2017-08-14 and GETDATE()";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel_1.EmployeeID = dr.GetInt32(0);
                            employeeModel_1.EmployeeName = dr.GetString(1);
                            employeeModel_1.StartDate = dr.GetDateTime(2);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public void Funcations()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel_2 = new EmployeeModel();
                using (this.connection)
                {
                    string sum = @"Select sum(Basic_pay) from employee_payroll where gender='M' GROUP BY gender";
                    string avg = @"Select avg(Basic_pay) from employee_payroll where gender='M' GROUP BY gender";
                    string max = @"Select max(Basic_pay) from employee_payroll where gender='F' GROUP BY gender";
                    string min = @"Select min(Basic_pay) from employee_payroll where gender='M' GROUP BY gender";
                    string count = @"Select count(Basic_pay) from employee_payroll where gender='F' GROUP BY gender";
                    //sum
                    SqlCommand Sumcmd = new SqlCommand(sum, this.connection);
                    this.connection.Open();
                    SqlDataReader sumdr = Sumcmd.ExecuteReader();
                    if (sumdr.HasRows)
                    {
                        while (sumdr.Read())
                        {
                            decimal Add = sumdr.GetDecimal(0);
                            Console.WriteLine("Salary Total = {0}", Add);
                        }
                    }
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                    //avg
                    SqlCommand avgcmd = new SqlCommand(avg, this.connection);
                    this.connection.Open();
                    SqlDataReader avgdr = avgcmd.ExecuteReader();
                    if (avgdr.HasRows)
                    {
                        while (avgdr.Read())
                        {
                            decimal Avg = avgdr.GetDecimal(0);
                            Console.WriteLine("Salary Total = {0}", Avg);
                        }
                    }
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                    //Max
                    SqlCommand maxcmd = new SqlCommand(max, this.connection);
                    this.connection.Open();
                    SqlDataReader maxdr = maxcmd.ExecuteReader();
                    if (maxdr.HasRows)
                    {
                        while (maxdr.Read())
                        {
                            decimal Max = maxdr.GetDecimal(0);
                            Console.WriteLine("Salary Total = {0}", Max);
                        }
                    }
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                    //Min
                    SqlCommand mincmd = new SqlCommand(min, this.connection);
                    this.connection.Open();
                    SqlDataReader mindr = mincmd.ExecuteReader();
                    if (mindr.HasRows)
                    {
                        while (mindr.Read())
                        {
                            decimal Min = mindr.GetDecimal(0);
                            Console.WriteLine("Salary Total = {0}", Min);
                        }
                    }
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                    //Count
                    SqlCommand countcmd = new SqlCommand(sum, this.connection);
                    this.connection.Open();
                    SqlDataReader countdr = countcmd.ExecuteReader();
                    if (countdr.HasRows)
                    {
                        while (countdr.Read())
                        {
                            decimal Count = countdr.GetDecimal(0);
                            Console.WriteLine("Salary Total = {0}", Count);
                        }
                    }
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();

                }
                
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
