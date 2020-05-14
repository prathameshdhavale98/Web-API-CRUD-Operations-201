using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI201.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class Employees
    {
        public Employees()
        {
        }

        public Employees(int employeeId, string employeeName, DateTime birthDate, string gender)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            BirthDate = birthDate;
            Gender = gender;
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
