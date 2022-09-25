using System;
using FirstConsoleProject.Models;
using FirstConsoleProject.Interfaces;
using FirstConsoleProject.Services;

namespace FirstConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IHumanResourceManager humanResourceManager= new HRManagerService();
            do
            {
                Console.WriteLine("Etmek Istediyiniz Emeliyyatin Nomresini Daxil Edin:");
                Console.WriteLine("1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine("2 - Departament yaratmaq");
                Console.WriteLine("3 - Departamentde deyishiklik etmek");
                Console.WriteLine("4 - Ishcilerin siyahisini gostermek");
                Console.WriteLine("5 - Departamentdeki ishcilerin siyahisini gostermek");
                Console.WriteLine("6 - Ishci elave etmek");
                Console.WriteLine("7 - Ishci uzerinde deyishiklik etmek");
                Console.WriteLine("8 - Departamentden ishci silinmesi");

                string answerStr = Console.ReadLine();
                int answerNum;

                while (!int.TryParse(answerStr, out answerNum) || answerNum < 1 || answerNum > 8)
                {
                    Console.WriteLine("Duzgun Secim Edin");
                    answerStr = Console.ReadLine();
                }
                switch (answerNum)
                {
                    case 1:
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        EditDepartaments(ref humanResourceManager);
                        break;
                    case 4:
                        ShowEmployees(ref humanResourceManager);
                        break;
                    case 5:
                        EmployeesInDepartment(ref humanResourceManager);
                        break;
                    case 6:
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    default:
                        break;
                }

            } while (true);
        }

        

        static void GetDepartments(ref IHumanResourceManager humanResourceManager)
        {
            humanResourceManager.GetDepartments();
        }
        static void AddEmployee(ref IHumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length<=0)
            {
                Console.WriteLine("Ilk Once Department Elave Edilmelidir");
                return;
            }
            Console.WriteLine("Elave Olunacaq Ishcinin Ad Ve Soyadini Daxil Edin");
            string fullname = Console.ReadLine();
            string newfullName = fullname.Trim();
            string[] arr = newfullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            newfullName = string.Join(' ', arr);
            Console.WriteLine("Ishcinin Vezifesini Daxil Edin:");
            string position = Console.ReadLine();
            while (position.Length<2)
            {
                Console.WriteLine("Vezife Adi minimum 2 Herfden Ibaret Olmalidir");
                position = Console.ReadLine();
            }
            Console.WriteLine("Ishcinin Maashini Daxil Edin:");
            string salaryStr = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryStr,out salary)||salary<250)
            {
                Console.WriteLine("Ishcinin Maashi 250 Manatdan Az Ola Bilmez");
                salaryStr = Console.ReadLine();
            }
            Console.WriteLine("Ishcinin Elave Olunacag Departmentin Adini Daxil Edin:");
            string departmentName = Console.ReadLine();
            while (departmentName.Length<2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidir");
                departmentName = Console.ReadLine();
            }
            humanResourceManager.AddEmployee(departmentName, fullname, position, salary);
        }

        static void EditEmployee(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Edit Olunacag Ishcinin No-sunu Daxil Edin");
            string no = Console.ReadLine();
            while (no.Length < 6)
            {
                Console.WriteLine("Ishcinin No-sunda Yerleshdiyi Departmentin Ilk 2 Herfi Ve 4 Reqem Olmalidir");
                return;
            }
            Console.WriteLine("Ishci Ucun Yeni Position Teyin Edin:");
            string newPosition = Console.ReadLine();
            while (newPosition.Length<2)
            {
                Console.WriteLine("Position Minimum 2 Herfden Ibaret Olmalidir");
                newPosition = Console.ReadLine();
            }
            Console.WriteLine("Ishci ucun Yeni Maash Teyin Edin");
            string salaryStr = Console.ReadLine();
            double newSalary;
            while (!double.TryParse(salaryStr, out newSalary) || newSalary < 250)
            {
                Console.WriteLine("Ishcinin Maashi 250 Manatdan Az Ola Bilmez");
                salaryStr = Console.ReadLine();
            }
            humanResourceManager.EditEmployee(no,newSalary,newPosition);

        }

        static void EditDepartaments(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Deyishmek Istediyiniz Departmentin Adini Yazin");
            string departmentName = Console.ReadLine();
            while (departmentName.Length<2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidir");
                departmentName = Console.ReadLine();
            }
            Console.WriteLine("Yeni Departmentin Adini Yazin");
            string newDepartmentName = Console.ReadLine();
            while (newDepartmentName.Length < 2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidir");
                newDepartmentName = Console.ReadLine();
            }
            humanResourceManager.EditDepartaments(departmentName, newDepartmentName);
        }

        static void AddDepartment(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Elave Etmek Istediyiniz Departmentin Adini Daxil Edin");
            string departmentName = Console.ReadLine();
            while (departmentName.Length<2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidi");
                departmentName = Console.ReadLine();
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                if (department.Name==departmentName)
                {
                    Console.WriteLine("Bu Adda Department Artiq Movcuddur");
                    departmentName = Console.ReadLine();
                }
            }
            Console.WriteLine("Departmentin Limitini Daxil Edin");
            string limitStr = Console.ReadLine();
            byte limit;
            while (!byte.TryParse(limitStr,out limit))
            {
                Console.WriteLine("Duzgun Limit Daxil Edin");
            }
            humanResourceManager.AddDepartment(departmentName, limit);
        }
        static void ShowEmployees(ref IHumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length==0)
            {
                Console.WriteLine("Ilk Once Department Yaradilmalidir");
                return;
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine($"Department:{department.Name}\nIshci No:{employee.No}\nIshcinin Ad Ve Soyadi:{employee.FullName}\nMaash:{employee.Salary}\nVezife:{employee.Position}");
                }
            }
        }
        static void EmployeesInDepartment(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Gormek Istediyiniz Departmentin Adini Daxil Edin:");
            string departmentName = Console.ReadLine();
            while (departmentName.Length < 2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidi");
                departmentName = Console.ReadLine();
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.WriteLine("Ilk Once Department Yaradilmalidir");
                    return;
                }
                if (departmentName.ToUpper() == department.Name.ToUpper())
                {
                    if (!(department.Employees.Length==0))
                    {
                        foreach (Employee employee in department.Employees)
                        {
                            Console.WriteLine($"Ishci No:{employee.No}\nIshcinin Ad Ve Soyadi:{employee.FullName}\nMaash:{employee.Salary}\nVezife:{employee.Position}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Bu Departmentde Ishci Yoxdur");
                    }
                }
                else
                {
                    Console.WriteLine("Bu Adda Department Movcud Deyil");
                }
                
            }
        }
        static void RemoveEmployee(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Ishcinin Oldugu Departmentin Adini Daxil Edin:");
            string departmentName = Console.ReadLine();
            while (departmentName.Length < 2)
            {
                Console.WriteLine("Department Adi Minimum 2 Herfden Ibaret Olmalidi");
                departmentName = Console.ReadLine();
            }
            Console.WriteLine("Silmek Istediyiniz Ishcinin No-sunu Daxil Edin:");
            string no = Console.ReadLine();
            while (no.Length<6)
            {
                Console.WriteLine("Ishcinin No-sunda Yerleshdiyi Departmentin Ilk 2 Herfi Ve 4 Reqem Olmalidir");
                no = Console.ReadLine();
            }
            humanResourceManager.RemoveEmployee(no, departmentName);
        }
    }
}

