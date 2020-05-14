using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.DataAccess.Service
{
    public class EmployeeData : IEmployeeData
    {
        private readonly EmployeeManagementContext _context;
        public EmployeeData(EmployeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Employees> GetEmployeeById(int id)
        {

            try
            {
                Employees employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return null;
                }
                else
                { 
                Employees employees = new Employees(employee.EmployeeId, employee.EmployeeName, employee.BirthDate, employee.Gender);
                return employees;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public async Task<List<Employees>> GetEmployeesDetails()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddEmployee(Employees employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return "Employee Added Sucessfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteEmployee(int id)
        {
            List<Employees> EmployeeList;
            bool isPresent = false;
            try
            {
                Employees employee = _context.Employees.Where(p => p.EmployeeId == id).FirstOrDefault();
                EmployeeList = await _context.Employees.Where(p => p.EmployeeId == id).ToListAsync();
                foreach (Employees emp in EmployeeList)
                {
                    if (employee.EmployeeId.Equals(id))
                    {
                        isPresent = true;
                        break;
                    }
                }
                if (isPresent)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return "Employee Deleted Successfully";
                }
                else
                {
                    return "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
