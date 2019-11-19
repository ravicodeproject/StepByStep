using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET api/GetEmployees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {         
            return Ok(await _context.Employees.ToListAsync());
        }

        // GET api/GetEmployees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees(int id)
        {         
            return Ok(await _context.Employees.FirstOrDefaultAsync(e => e.Eid==id));
        }
    }
}