using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]

    public class CompanyController : BaseAPIController
    {
        private readonly IGenericRepository<Company> _companyRepo;
        private readonly IMapper _mapper;

        public CompanyController(IGenericRepository<Company> companyRepo
            , IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Company>> AddCompany(CompanyDto companyDto)
        {
            try
            {
                var company = _mapper.Map<CompanyDto, Company>(companyDto);
                await _companyRepo.Add(company);
                return Ok(company);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpPut]
        public async Task<ActionResult<Company>> UpdateCompany()
        {
            var comp = new Company
            {
                Id = 99,
                Exchange = "exchange",
                Ticker = "sss123",
                Name = "Test",
                ISIN = "isintest1",
                Website = "ssswww"
            };

            var spec = new CompanyWithExchangeSpecification(comp.Id);
            var company = await _companyRepo.GetEntityWithSpec(spec);
            company.Ticker = comp.Ticker;
            await _companyRepo.Update(company);

            return Ok(company);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyDto>>> GetCompany()
        {
            var spec = new CompanyWithExchangeSpecification();
            var companies = await _companyRepo.ListAsync(spec);
            return _mapper.Map<IReadOnlyList<Company>, List<CompanyDto>>(companies);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var spec = new CompanyWithExchangeSpecification(id);
            var company = await _companyRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Company, CompanyDto>(company);
        }

        [HttpGet("isin/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(string id)
        {
            var spec = new CompanyWithExchangeSpecification(id);
            var company = await _companyRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Company, CompanyDto>(company);
        }
    }
}