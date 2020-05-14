using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Domain.Entities;

namespace WebAPI201.DataAccess.Repository
{
    public interface IEmployeeData
    {
        Task<Employees> GetEmployeeById(int id);
        Task<List<Employees>> GetEmployeesDetails();
        Task<string> AddEmployee(Employees employee);
        Task<string> DeleteEmployee(int id);
    }
}