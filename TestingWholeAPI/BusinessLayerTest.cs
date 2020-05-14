using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Business.Service;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace TestingWholeAPI
{
    [TestClass]
    public class BusinessLayerTest
    {
        [TestMethod]
        public async Task GetEmployeesDetails()
        {
            Mock<IEmployeeData> mock = new Mock<IEmployeeData>();
            //Arrange
            List<Employees> employeeList = new List<Employees>()
            {


            };
            mock.Setup(x => x.GetEmployeesDetails()).ReturnsAsync(employeeList);
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(mock.Object);
            //Act
            object actual = await employeeBusiness.GetEmployeesDetails();
            //Assert
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public async Task GetEmployeesById()
        {
            

            Mock<IEmployeeData> mock = new Mock<IEmployeeData>();

            //Arrange
            Employees employee = new Employees();
            {
                employee.EmployeeId = 1;
                employee.EmployeeName = "Prathamesh";
                employee.Gender = "male";
                employee.BirthDate = DateTime.Now;
               

            }
            mock.Setup(x => x.GetEmployeeById(1)).ReturnsAsync(employee);

            EmployeeBusiness userBusiness = new EmployeeBusiness(mock.Object);
            //Act
            object actual = await userBusiness.GetEmployeeById(1);

            //Assert
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public async Task AddEmployee_ShouldAddEmployee()
        {
            Mock<IEmployeeData> mock = new Mock<IEmployeeData>();
            //Arrange
            Employees employee = new Employees()
            {
                EmployeeId = 1,
                EmployeeName = "Prathamesh",
                Gender = "Male",
                BirthDate = System.DateTime.Now
            };
            mock.Setup(x => x.AddEmployee(employee)).ReturnsAsync("added");
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(mock.Object);
            //Act
            string actual = await employeeBusiness.AddEmployee(employee);
            //Assert
            Assert.AreEqual(actual, "added");
        }
        
        [TestMethod]
        public async Task DeleteEmployee_ShouldDeleteEmployee()
        {
            Mock<IEmployeeData> mock = new Mock<IEmployeeData>();
            //Arrange
            Employees employee = new Employees();
            employee.EmployeeId = 1;
            mock.Setup(x => x.DeleteEmployee(employee.EmployeeId)).ReturnsAsync("deleted");
            EmployeeBusiness employeeBusiness = new EmployeeBusiness(mock.Object);
            //Act
            string actual = await employeeBusiness.DeleteEmployee(employee.EmployeeId);
            //Assert
            Assert.AreEqual(actual, "deleted");
        }

    }

}
