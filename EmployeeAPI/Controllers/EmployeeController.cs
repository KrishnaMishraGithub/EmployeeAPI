using EmployeeAPI.Context;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDepartmentDBContext employeeDepartmentDBContext = new EmployeeDepartmentDBContext();

      
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        { 
            return employeeDepartmentDBContext.Employees.ToList();
        }
        [HttpPost]
        //[Route("api/[controller]")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employeeDepartmentDBContext.Employees.Add(employee);
            //employeeDepartmentDBContext.SaveChanges();
            return Ok(employeeDepartmentDBContext.SaveChanges());
        }
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id ,Employee employee)
        {
            var update=  employeeDepartmentDBContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            employeeDepartmentDBContext.Remove(update);
            update.FirstName = employee.FirstName;
            update.LastName = employee.LastName;
            update.Gender = employee.Gender;
            update.Salary = employee.Salary;
            update.Age = employee.Age;
            update.Department.DepartmentName = employee.Department.DepartmentName;
            employeeDepartmentDBContext.Add(update);
            employeeDepartmentDBContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
           var delete= employeeDepartmentDBContext.Employees.Where(d => d.EmployeeId == id).FirstOrDefault();
            employeeDepartmentDBContext.Remove(delete);
            employeeDepartmentDBContext.SaveChanges();
            return Ok();
        }
    }
}
