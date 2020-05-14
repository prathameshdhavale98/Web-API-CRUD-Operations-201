using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI201.DataAccess.Service;
using WebAPI201.Domain.Entities;

namespace TestingWholeAPI
{
    [TestClass]
    public class DataLayerTest
    {
        [TestMethod]
        public async Task GetEmployeeById_ShouldGetEmployeeById_Happy()
        {
            Employees employee = new Employees();
            // arrange
            int EmpployeeId = 1;
            var mockSet = new Mock<DbSet<Employees>>();
            mockSet.Setup(m => m.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(employee));

            var mockContext = new Mock<EmployeeManagementContext>();
            mockContext.Setup(m => m.Employees).Returns(mockSet.Object);
            var service = new EmployeeData(mockContext.Object);

            await service.GetEmployeeById(EmpployeeId);
            mockSet.Verify(m => m.FindAsync(It.IsAny<int>()), Times.Once());
        }
    }
}
