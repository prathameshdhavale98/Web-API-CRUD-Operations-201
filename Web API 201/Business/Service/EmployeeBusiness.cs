using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Business.Repository;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.Business.Service
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeData _employeeData;
        public EmployeeBusiness(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public async Task<Employees> GetEmployeeById(int id)
        {
            return await _employeeData.GetEmployeeById(id);
        }

        public async Task<List<Employees>> GetEmployeesDetails()
        {
            return await _employeeData.GetEmployeesDetails();
        }

        public async Task<string> AddEmployee(Employees employee)
        {
            string message = await _employeeData.AddEmployee(employee);
            return message;
        }

        public async Task<string> DeleteEmployee(int id)
        {
            string message = await _employeeData.DeleteEmployee(id);
            return message;
        }
    }
}
