using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using DataObject;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace StuhubPartner.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private RepositoryContext _repositoryContext;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly ILocationRepository _locationRepository;
        public SetupController(ICityRepository cityRepository,ILocationRepository locationRepository, IAddressRepository addressRepository, IDistrictRepository districtRepository, RepositoryContext repositoryContext, IMapper mapper)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;
            _repositoryContext = repositoryContext;
            _addressRepository = addressRepository;
            _locationRepository = locationRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityAddDTO _city)
        {
            var city = _mapper.Map<City>(_city);
            _cityRepository.Create(city);
            await _cityRepository.SaveAsync();
            return Ok();
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AddDistrict([FromBody] DistrictAddDTO _district, int id)
        {
            var _city = await _cityRepository.FindByIdAsync(id);
            _district.City = _city;
            var district = _mapper.Map<District>(_district);
            _districtRepository.Create(district);
            await _districtRepository.SaveAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<List<City>> ShowCity()
        {
            var cities = await _cityRepository.FindAll();
            return cities;
        }
        [HttpGet]
        public async Task<List<District>> ShowDistrict(int id)
        {
            var district = await _repositoryContext.Districts.Where(x => x.CityID == id)
                                                             .AsNoTracking().ToListAsync();
            return district;
        }
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody]  LocationDTO _location)
        {
            var city = await _cityRepository.FindByIdAsync(_location.CityID);
            var district = await _districtRepository.FindByIdAsync(_location.DistrictID);
            Address address = new Address
            {
                City = city,
                District = district
            };
            _location.Address = address;
            var location = _mapper.Map<Location>(_location);
            _addressRepository.Create(address);
            _locationRepository.Create(location);
           await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
    }
}
