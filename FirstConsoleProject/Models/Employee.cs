using System;
namespace FirstConsoleProject.Models
{
    public class Employee
    {
        private static int _no;
        public readonly string No;
        public string FullName;
        public string DepartmentName;
        public string Position;
        public double Salary;

        public void CheckSalary()
        {
            if (Salary >= 250)
            {
                Console.WriteLine($"Maash: {Salary}");
            }
            else
            {
                Console.WriteLine("Maash 250den Ashagi Ola Bilmez!");
            }
        }

        public void CheckPosition()
        {
            if (Position.Length<2)
            {
                Console.WriteLine("Position Minimum 2 Herfden Ibaret Olmalidir");
            }
            return;
        }

        static Employee()
        {
            _no = 1000;
        }

        public Employee(string fullname,string position, string department,double salary)
        {
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = department.ToUpper();
            _no++;
            No = DepartmentName.Substring(0,2)+ _no;
            
        }
        public override string ToString()
        {
            return $"No:{No}\nFullName: {FullName}\nPosition: {Position}\nSalary: {Salary}\nDepartment:{DepartmentName}"; 
        }
    }
}

