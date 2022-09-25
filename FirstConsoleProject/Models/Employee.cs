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
                Console.WriteLine("Maash 250den ashagi ola bilmez!");
            }
        }

        public void CheckPosition()
        {
            if (Position.Length<2)
            {
                Console.WriteLine("Position minimum 2 herfden ibaret olmalidir");
            }
            return;
        }

        public bool CheckFullName(string fullname)
        {
            string newfullName = fullname.Trim();
            string[] arr = newfullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            newfullName = string.Join(' ', arr);

            if (string.IsNullOrEmpty(fullname) && char.IsUpper(fullname[0]) && newfullName.Length==fullname.Length)
            {
                for (int i = 1; i < fullname.Length; i++)
                {
                    if (char.IsLower(fullname[i]) || (fullname[i] == ' ' && char.IsUpper(fullname[i + 1])))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;

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

