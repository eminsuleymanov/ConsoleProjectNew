using System;
using FirstConsoleProject.Interfaces;
using FirstConsoleProject.Models;

namespace FirstConsoleProject.Services
{
    public class HRManagerService:IHumanResourceManager
    {
        
        private Department[] _departments;

        public HRManagerService()
        {
            _departments = new Department[0];
        }

        public Department[] Departments => _departments;
        

        public void AddDepartment(string departmentName, int workerLimit, double salary)
        {
            Department department = new Department(departmentName, workerLimit, salary);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;

        }

        public void GetDepartments()
        {
            foreach (Department item in Departments)
            {
                Console.WriteLine(item);
            }

        }

        public void EditDepartaments(string oldname, string newName)
        {
            foreach (Department department in Departments)
            {
                if (department.Name.ToUpper() == oldname.ToUpper())
                {
                    department.Name = newName;
                }
                else
                {
                    Console.WriteLine("Yazilan adda department yoxdur");
                }

            }
        }


        public void AddEmployee( string fullname,string departmentName, string position, double salary)
        {
            foreach (Department department in Departments)
            {
                if (department.Name.ToUpper()==departmentName.ToUpper())
                {
                    if (department.WorkerLimit> department.Employees.Length)
                    {
                        Employee employee = new Employee(fullname, position,departmentName, salary);
                        Array.Resize(ref department.Employees, department.Employees.Length + 1);
                        department.Employees[department.Employees.Length - 1] = employee;
                    }
                    else
                    {
                        Console.WriteLine($"{department.Name} -da employee limiti ashilib");
                    }

                }
            }
        }
        

        public void EditEmployee(string departmentName, string newFullname, string newPosition, double newSalary, string no)
        {
            foreach (Department department in Departments)
            {
                if (department.Name.ToUpper()==departmentName.ToUpper())
                {
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i].No.ToUpper()==no.ToUpper())
                        {
                            department.Employees[i].Salary = newSalary;
                            department.Employees[i].Position = newPosition;
                            department.Employees[i].FullName = newFullname;
                        }
                        else
                        {
                            Console.WriteLine($"{department.Employees} - da bele ishci yoxdur");
                        }
                    }
                }

            }
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            throw new NotImplementedException();
        }
    }
}

