using API.Dtos;
using API.Error;
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

        [HttpGet("emailexists")]
        public async Task<ActionResult<CompanyDto>> CheckISINExistsAsync([FromQuery] string isin)
        {
            try
            {
                var company = await GetCompany(isin);
                return company;
            }
            catch (Exception ex)
            {
                throw;
                //ToDo:
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SaveCompany(CompanyDto companyDto)
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
                    var result = CheckISINExistsAsync(company.ISIN);
                    if (result.Result.Value != null)
                    {
                        return new BadRequestObjectResult(new ErrorResponse { Errors = new[] { "ISIN already exists." } });
                    }

                    await _companyRepo.Add(company);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyDto>>> GetCompany()
        {
            try
            {
                var spec = new CompanyWithExchangeSpecification();
                var companies = await _companyRepo.ListAsync(spec);
                return _mapper.Map<IReadOnlyList<Company>, List<CompanyDto>>(companies);
            }
            catch (Exception ex)
            {
                throw;
                //ToDo:
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            try
            {
                var spec = new CompanyWithExchangeSpecification(id);
                var company = await _companyRepo.GetEntityWithSpec(spec);
                return _mapper.Map<Company, CompanyDto>(company);
            }
            catch (Exception ex)
            {
                throw;
                //ToDo:
            }
        }

        [HttpGet("isin/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(string id)
        {
            try
            {
                var spec = new CompanyWithExchangeSpecification(id);
                var company = await _companyRepo.GetEntityWithSpec(spec);
                return _mapper.Map<Company, CompanyDto>(company);
            }
            catch (Exception ex)
            {
                throw;
                //ToDo:
            }
        }
    }
}