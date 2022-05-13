using EmployeeAPI.Context;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        EmployeeDepartmentDBContext employeeDepartmentDBContext = new EmployeeDepartmentDBContext();
        [HttpGet]
        public List<Department> GetDepartment()
        {
           return employeeDepartmentDBContext.Departments.ToList();
        }
        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            employeeDepartmentDBContext.Departments.Add(department);
            return Ok(employeeDepartmentDBContext.SaveChanges());
        }

        [HttpPut]
        [Route("UpdateDepartment/{id}")]
        public IActionResult UpdateDepartment(int id,[FromBody] Department department)
        {
            
            var update= employeeDepartmentDBContext.Departments.Where(e => e.DepartmentId == id).FirstOrDefault();
            employeeDepartmentDBContext.Remove(update);
            update.DepartmentName = department.DepartmentName;
            employeeDepartmentDBContext.Add(update);
            employeeDepartmentDBContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {   
           
            var delete= employeeDepartmentDBContext.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            employeeDepartmentDBContext.Remove(delete);
            employeeDepartmentDBContext.SaveChanges();
            return Ok();
        }
    }
}
