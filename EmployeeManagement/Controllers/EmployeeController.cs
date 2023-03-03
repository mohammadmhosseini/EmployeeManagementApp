using EmployeeManagement.Data;
using EmployeeManagement.Dtos;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddEmployee(UpsertEmployeeDto model)
        {
            if(ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    FullName = model.FullName,
                    PersonnelCode = model.PersonnelCode,
                    InternalNumber = model.InternalNumber,
                    Building = model.Building,
                    Floor = model.Floor,
                    Room = model.Room,
                };
                await _appDbContext.Employees.AddAsync(newEmployee);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> EditEmployee(int employeeId, UpsertEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employeeFromDb = await _appDbContext.Employees.FindAsync(employeeId);
                if(employeeFromDb == null)
                {
                    return NotFound();
                }

                employeeFromDb.FullName = model.FullName;
                employeeFromDb.PersonnelCode = model.PersonnelCode;
                employeeFromDb.InternalNumber = model.InternalNumber;
                employeeFromDb.Building = model.Building;
                employeeFromDb.Floor = model.Floor;
                employeeFromDb.Room = model.Room;

                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
