using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IGenericRepository<Company> _companyRepo;
        public CompanyController(IGenericRepository<Company> companyRepo)
        {
            _companyRepo = companyRepo;
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
            var comp = new Company();
            //{
            //    //Id = 1,
            //    Name = "Test",
            //    ISIN = "isintest"
            //};
            //comp.Exchange = new Exchange { Name = "test exch", Id = 2 };

            return Ok(comp);
        }
        [HttpGet]
        public async Task<ActionResult<Company>> GetCompany()
        {
            var spec = new CompanyWithExchangeSpecification();
            var comp = await _companyRepo.ListAsync(spec);
            return Ok(comp);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var spec = new CompanyWithExchangeSpecification(id);
            var comp = await _companyRepo.GetEntityWithSpec(spec);
            //return _mapper.Map<Product, ProductsToReturnDto>(product);

            return Ok(comp);
        }

        [HttpGet("isin/{id}")]
        public async Task<ActionResult<Company>> GetCompany(string id)
        {
            var spec = new CompanyWithExchangeSpecification(id);
            var comp = await _companyRepo.GetEntityWithSpec(spec);
            //return _mapper.Map<Product, ProductsToReturnDto>(product);

            return Ok(comp);
        }
    }
}