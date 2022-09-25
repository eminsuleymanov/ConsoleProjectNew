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
        

        public void AddDepartment(string departmentName, int workerLimit)
        {
            Department department = new Department(departmentName, workerLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;

        }

        public void GetDepartments()
        {
            if (Departments.Length == 0)
            {
                Console.WriteLine("Ilk Once Department Yaradilmalidir");
                return;
            }
            foreach (Department department in Departments)
            {
                Console.WriteLine($"Departmentin Adi:{department.Name}\nOrtalama Maash:{department.AverageSalary}");
            }

        }

        public void EditDepartaments(string oldname, string newName)
        {
            if (Departments.Length == 0)
            {
                Console.WriteLine("Ilk Once Department Yaradilmalidir");
                return;
            }
            foreach (Department department in Departments)
            {
                if (department.Name.ToUpper() == oldname.ToUpper())
                {
                    department.Name = newName;
                }
                else
                {
                    Console.WriteLine("Yazilan Adda Department Yoxdur");
                    return;
                }

            }
        }

        public void AddEmployee( string fullname,string departmentName, string position, double salary)
        {
            if (!string.IsNullOrEmpty(fullname) || char.IsUpper(fullname[0]))
            {
                for (int i = 1; i < fullname.Length; i++)
                {
                    if (char.IsLower(fullname[i]) || (fullname[i] == ' ' && char.IsUpper(fullname[i + 1])))
                    {
                        return;
                    }
                    Console.WriteLine("Ad ve Soyad Arasinda Bir Boshlug Olmalidir");
                    fullname = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Adin Ilk Herfi Boyuk Herf Olmalidir ve Boshlug Gonderilmemelidir!");
                fullname = Console.ReadLine();
            }
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

        public void EditEmployee(string newPosition, double newSalary, string no)
        {
            foreach (Department department in Departments)
            {
                for (int i = 0; i < department.Employees.Length; i++)
                {
                    if (department.Employees[i].No.ToUpper() == no.ToUpper())
                    {
                        department.Employees[i].Salary = newSalary;
                        department.Employees[i].Position = newPosition;
                    }
                    else
                    {
                        Console.WriteLine($"{department.Employees} - da Bele Ishci Yoxdur");
                    }
                }

            }
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            Employee temp = null;
            if (Departments.Length==0)
            {
                Console.WriteLine("Ilk Once Department Yaradilmalidir");
                return;
            }
            foreach (Department department in Departments)
            {
                if (departmentName.ToUpper()==department.Name.ToUpper())
                {
                    if (department.Employees.Length==0)
                    {
                        Console.WriteLine("Bu Departmentde Ishci yoxdur");
                        
                    }
                    else
                    {
                        for (int i = 0; i < department.Employees.Length; i++)
                        {
                            if (department.Employees[i].No.ToUpper()==no.ToUpper())
                            {
                                temp = department.Employees[i];
                                department.Employees[i] = department.Employees[department.Employees.Length - 1];
                                department.Employees[department.Employees.Length - 1] = temp;
                                Array.Resize(ref department.Employees, department.Employees.Length - 1);

                            }
                            else
                            {
                                Console.WriteLine("Bele No-lu Ishci Yoxdur");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bu Adda Department Yoxdur");
                }

            }
        }
    }
}

