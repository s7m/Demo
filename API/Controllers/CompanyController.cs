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
        public async Task<ActionResult<Company>> SaveCompany(CompanyDto companyDto)
        {
            try
            {
                var company = _mapper.Map<CompanyDto, Company>(companyDto);

                if (company.Id > 0)
                {
                    await _companyRepo.Update(company);
                }
                else
                {
                    await _companyRepo.Add(company);
                }
                return Ok(company);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpPut] //Method not using now. SaveCompany is taking care of both insert and update
        //public async Task<ActionResult<Company>> UpdateCompany(CompanyDto companyDto)
        //{
        //    var company = _mapper.Map<CompanyDto, Company>(companyDto);
        //    var spec = new CompanyWithExchangeSpecification(company.Id);
        //    var company = await _companyRepo.GetEntityWithSpec(spec);
        //    await _companyRepo.Update(company);

        //    return Ok(company);
        //}
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