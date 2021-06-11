using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendUsers.Models.Database;
using BackendUsers.Models.Entities;
using BackendUsers.Models;
using BackendUsers.BL.Interfaces;

namespace BackendUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DbContainer context;
        private readonly IEmployeeRepo employee;

        public EmployeesController(DbContainer _context , IEmployeeRepo employee )
        {
            this.context = _context;
            this.employee = employee;
        }

        //GET: api/Employees
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await context.Employee.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<IQueryable<EmployeeVM>>> Get()
        //{

        //    var data =await context.Employee
        //               .Select(a =>  new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Email = a.Email}).ToListAsync();
        //    return  Ok(data);
        // }



        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id , Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            context.Employee.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            context.Employee.Remove(employee);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return context.Employee.Any(e => e.Id == id);
        }
    }
}
