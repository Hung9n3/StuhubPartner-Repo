using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using DataObject;
using DataObject.EmployeePost;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StuhubPartner.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IEmployeeInfoRepository _employeeInfoRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAddressRepository _addressRepository;
        private IMapper _mapper;
        public EmployeeController(RepositoryContext repositoryContext, IEmployeeInfoRepository employeeInfoRepository, IAddressRepository addressRepository,
                                 ILocationRepository locationRepository, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _employeeInfoRepository = employeeInfoRepository;
            _locationRepository = locationRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _employeeInfoRepository.FindAll();
            var _employee = _mapper.Map<EmployeeDTO>(employee);
            return Ok(_employee);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeInfoRepository.FindByIdAsync(id);
            var _employee = _mapper.Map<EmployeeDTO>(employee);
            return Ok(_employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeePost employeeDTO)
        {
            var address = _mapper.Map<Address>(employeeDTO);
            _addressRepository.Create(address);
            await _repositoryContext.SaveChangesAsync();
            employeeDTO.Address = address;
            var employee = _mapper.Map<EmployeeInfo>(employeeDTO);
            _employeeInfoRepository.Create(employee);
            await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeePost employeeDTO)
        {
            var employee = await _employeeInfoRepository.FindByIdAsync(id);
            _mapper.Map(employeeDTO, employee.Address);
            _addressRepository.Update(employee.Address);
            await _addressRepository.SaveChangesAsync();
            _mapper.Map(employeeDTO, employee);
            _employeeInfoRepository.Update(employee);
            await _employeeInfoRepository.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _employeeInfoRepository.FindByIdAsync(id);
            _addressRepository.Delete(employee.Address);
            _employeeInfoRepository.Delete(employee);
            await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
    }
}
