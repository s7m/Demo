using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CompanyController(CompanyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany()
        {
            var comp = new Company
            {
                //Id = 1,
                Name = "Test",
                ISIN = "isintest"
            };
            //comp.Exchange = new Exchange { Name = "test exch", Id = 2 };

            return Ok(comp);
        }

        [HttpPut]
        public async Task<ActionResult<Company>> UpdateCompany()
        {
            var comp = new Company
            {
                //Id = 1,
                Name = "Test",
                ISIN = "isintest"
            };
            //comp.Exchange = new Exchange { Name = "test exch", Id = 2 };

            return Ok(comp);
        }
        [HttpGet]
        public async Task<ActionResult<Company>> GetCompany()
        {
            // var comp = new Company
            // {
            //    // Id = 1,
            //     Name = "Test",
            //     ISIN = "isintest"
            // };
            //comp.Exchange = new Exchange { Name = "test exch", Id = 2 };
            var comp = await _context.Companies.ToListAsync();
            return Ok(comp);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var comp = await _context.Companies.FindAsync(id);
            //comp.Exchange = new Exchange { Name = "test exch", Id = 2 };

            return Ok(comp);
        }

        [HttpGet("isin/{id}")]
        public async Task<ActionResult<Company>> GetCompany(string isin)
        {
            var comp = await _context.Companies.FindAsync(isin);
           // comp.Exchange = new Exchange { Name = "test exch", Id = 2 };

            return Ok(comp);
        }
    }
}