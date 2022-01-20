using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TestTask.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _context;
        public EmployeeController(IEmployeeRepository context)
        {
            _context = context;
        }
        [Route("/getemployees")]
        [HttpGet]
        public async Task<IEnumerable<EmployeeVm>> GetEmployees()
        {
            var employees = await _context.GetEmployees();
            var employeesVm = employees.Select(employee => new EmployeeVm(employee));
            return employeesVm;
        }
        [Route("/add")]
        [HttpPost]
        public async Task<Response> AddEmployee([FromBody] Employee employee)
        {
            var success = await _context.AddEmployee(employee);
            return new Response(success.Item1, success.Item2);
        }
        [Route("/add")]
        [HttpGet]
        public IActionResult RedirectHome()
        {
            return Redirect("/");
        }
        [Route("/delete/{id}")]
        [HttpDelete]
        public async Task<Response> DeleteEmployee(int id)
        {
            var success = await _context.DeleteEmployee(id);
            return new Response(success.Item1, success.Item2);
        }
    }
}
