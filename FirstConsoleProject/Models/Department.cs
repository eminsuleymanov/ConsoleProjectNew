using System;
namespace FirstConsoleProject.Models
{
    public class Department
    {
        public string Name;
        public int WorkerLimit;
        static double _salaryLimit;
        public Employee[] Employees;
        public double SalaryLimit { get => _salaryLimit;
            set
            {
                if (_salaryLimit>Employees.Length*250)
                {
                    _salaryLimit = value;
                }
                else
                {
                    Console.WriteLine("Butun isceler ucun ayliq cemi verilecek minimum mebleg 250 manat olmalidir");
                }
            }
        }
        public double CalcSalaryAverage()
        {
            double averageSalary = 0;
            double sumSalary = 0;
            foreach (Employee item in Employees)
            {
                sumSalary += item.Salary;

            }
            averageSalary = sumSalary / Employees.Length;
            return averageSalary;
        }
        public Department(string name, int workerLimit, double salaryLimit)
        {
            Employees = new Employee[0];
        }
    }
}

