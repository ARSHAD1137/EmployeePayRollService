using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Employee Payroll!");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            /*
           employee.EmployeeName = "Mohan";
           employee.Department = "Tech1";
           employee.PhoneNumber = "6302907678";
           employee.Address = "02-Patna";
           employee.Gender = 'M';
           employee.BasicPay = 10000.00M;
           employee.Deductions = 1500.00;
           employee.StartDate = Convert.ToDateTime("2020-11-03");

           if (repo.AddEmployee(employee))
           Console.WriteLine("Records added successfully");

            employee.EmployeeID =2;
            employee.BasicPay = 3000000;
            if (repo.UpdateEmployeeDetails(employee))
            Console.WriteLine("Records update successfully");*/
            //repo.GetAllEmployee();

            //repo.ReterieveData();
            repo.Funcations();
            Console.ReadKey();
        }
    }


}
