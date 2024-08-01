using EmployerAdminPortal.Data;
using EmployerAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployerAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployers()
        {
            var allEmployes= dbContext.Employers.ToList();

            return Ok(allEmployes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeById(int id)
        { 
            var EmployersById=dbContext.Employers.Find(id);
            if(EmployersById==null) { return NotFound();
            
            }
            return Ok(EmployersById);

        }

        [HttpPost]
        public IActionResult AddEmployers(EmployerDto employerDto)
        {
            var addEmployers= new Employer()
            { Name=employerDto.Name,
             Email =employerDto.Email,
             Phone =employerDto.Phone,
             Salary =employerDto.Salary,
             };

        dbContext.Add(addEmployers);
            dbContext.SaveChanges();

            return Ok(addEmployers);

        }


        [HttpPost]
        [Route("{id:int}")]
        public IActionResult UpdateEmployers(int id, EmployerDto employerDto)


        {
            var UpdateEmployers = dbContext.Employers.Find(id);
            if(UpdateEmployers==null) { return NotFound(); }

            UpdateEmployers.Name = employerDto.Name;
            UpdateEmployers.Email = employerDto.Email;
            UpdateEmployers.Phone = employerDto.Phone;
            UpdateEmployers.Salary = employerDto.Salary;
            dbContext.SaveChanges();

            return Ok(UpdateEmployers);
        }


        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteEmployers(int id)
        { 
        var DeleteEmployers= dbContext.Employers.Find(id);
            if(DeleteEmployers==null) { return NotFound(); }

            dbContext.Employers.Remove(DeleteEmployers);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
