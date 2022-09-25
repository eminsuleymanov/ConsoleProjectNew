using System;
using FirstConsoleProject.Models;

namespace FirstConsoleProject.Interfaces
{
    public interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string departmentName,int workerLimit);
        void EditDepartaments(string name,string newName);
        void GetDepartments();
        void AddEmployee(string departmentName,string fullname, string position, double salary);
        void EditEmployee(string newPosition, double newSalary,string no);
        void RemoveEmployee(string no,string departmentName);
        
    }
}

