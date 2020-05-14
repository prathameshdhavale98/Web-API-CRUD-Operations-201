using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI201.Business.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
               
                var entity= await _employeeBusiness.GetEmployeeById(id);
                if (entity != null)
                {
                    return StatusCode(StatusCodes.Status200OK, entity);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee with Id = " + id.ToString() + " not found");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployeesDetails")]
        public async Task<IActionResult> GetEmployeesDetails()
        {
            try
            {
                return Ok(await _employeeBusiness.GetEmployeesDetails());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public  ActionResult AddEmployee([FromBody] Employees employee)
        {
            try
            {
                _employeeBusiness.AddEmployee(employee);
                return StatusCode(StatusCodes.Status201Created,"Employee Added Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var entity = await _employeeBusiness.DeleteEmployee(id);
                if (entity.Equals("Employee Not Found"))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee with Id = " + id.ToString() + " not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}