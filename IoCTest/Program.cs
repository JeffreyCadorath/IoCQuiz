using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCTest
{
    public interface IEmployee
    {
        double GetEmployeeSalary(int Id);
        string GetTop3Salarys();
        int GetHiringDate(int Id);
    }

    public class EmployeeDataAccess : IEmployee
    {
        IoCDatabaseEntities db = new IoCDatabaseEntities();
        public double GetEmployeeSalary(int Id)
        {
            var employee = db.Employees.Find(Id);
            var salary = employee.Salary;
            return salary;
        }
        public int GetHiringDate(int Id)
        {
            var employee = db.Employees.Find(Id);
            return employee.HiringDate.Year;
        }

        public string GetTop3Salarys()
        {
            var employees = db.Employees.OrderBy(x => x.Salary).Take(3).ToList();
            foreach(var item in employees)
            {
                return item.Salary.ToString();
            }
            return " ";
        }
    }
    
    public class EmployeeBusinessLogic
    {
        IEmployee iEmployee;
        public EmployeeBusinessLogic(IEmployee _iEmployee)
        {
            this.iEmployee = _iEmployee;
        }

        public double handleEmployeeSalary(int Id)
        {
           return iEmployee.GetEmployeeSalary(Id);
        }
        public string handleTop3EmployeeSalarys()
        {
            return iEmployee.GetTop3Salarys();
        }
        public double calculateBonus(int Id)
        {
            var hiringDate = iEmployee.GetHiringDate(Id);
            return (iEmployee.GetEmployeeSalary(Id) * ((float)hiringDate / 100));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
