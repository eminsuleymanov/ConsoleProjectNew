using System;
namespace FirstConsoleProject.Models
{
    public class Department
    {
        public string Name;
        public int WorkerLimit;
        static double _salaryLimit;
        public double AverageSalary;
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
                    Console.WriteLine("Butun Ishceler Ucun Ayliq Cemi Verilecek Minimum Mebleg 250 Manat Olmalidir");
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
            AverageSalary = averageSalary;
            return AverageSalary;
        }
        public Department(string name, int workerLimit)
        {
            Employees = new Employee[0];
        }
    }
}

