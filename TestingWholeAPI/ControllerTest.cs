using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI201.Business.Repository;
using WebAPI201.Controllers;
using WebAPI201.Domain.Entities;

namespace TestingWholeAPI
{
    [TestClass]
    public class ControllerTest
    {
        private Mock<IEmployeeBusiness> _mockemployeeBusiness = new Mock<IEmployeeBusiness>();
        private EmployeeController _controller;

        public ControllerTest()
        {
            _controller = new EmployeeController(_mockemployeeBusiness.Object); // <1>
        }

        [TestMethod]
        public async Task GetEmployeeById_ShouldGetEmployeeById()
        {
            var actionResult = await _controller.GetEmployeeById(1);
            Assert.IsNotNull(actionResult);
           
        }
        [TestMethod]
        public async Task GetEmployeeDetails_ShouldGetEmployeeDetails()
        {
            var actionResult =await _controller.GetEmployeesDetails();
            Assert.IsNotNull(actionResult);

        }
        [TestMethod]
        public async Task AddEmployee_ShouldAddEmployee()
        {
            Employees employee = new Employees();
            {
                employee.EmployeeId = 1;
                employee.EmployeeName = "Prathamesh";
                employee.Gender = "male";
                employee.BirthDate = DateTime.Now;


            }
            var actionResult =  _controller.AddEmployee(employee);
            Assert.IsNotNull(actionResult);

        }
        [TestMethod]
        public async Task DeleteEmployee_ShouldDeleteEmployee()
        {
            Employees employee = new Employees();
            {
                employee.EmployeeId = 1;
                employee.EmployeeName = "Prathamesh";
                employee.Gender = "male";
                employee.BirthDate = DateTime.Now;
            }
            var actionResult = _controller.DeleteEmployee(employee.EmployeeId);
            Assert.IsNotNull(actionResult);

        }
    }
}
