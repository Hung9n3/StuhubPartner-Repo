using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using DataObject;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StuhubPartner.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StuhubController : ControllerBase
    {
        private RepositoryContext _repositoryContext;
        private readonly ICityRepository cityRepository;
        private readonly IDistrictRepository districtRepository;
        private readonly IMapper _mapper;
        public StuhubController(ICityRepository cityRepository, IDistrictRepository districtRepository, RepositoryContext repositoryContext, IMapper mapper)
        {
            _mapper = mapper;
            this.districtRepository = districtRepository;
            this.cityRepository = cityRepository;
            _repositoryContext = repositoryContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDTO _city)
        {

            var city = _mapper.Map<City>(_city);
            cityRepository.Create(city);
            await cityRepository.SaveAsync();
            return Ok(cityRepository.FindAll());
        }
        [HttpGet("{id}")]
        public async Task<CityDTO> GetCityById(int id)
        {
            var _city = await cityRepository.FindByIdAsync(id);
            var City = _mapper.Map<CityDTO>(_city);
            ICollection<District> districts = _city.Districts;
            return City;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AddDistrict([FromBody] DistrictDTO _district, int id)
        {
            var _city = await cityRepository.FindByIdAsync(id);
            _district.CityId = id;
            _district.city = _city;
            var district = _mapper.Map<District>(_district);
            districtRepository.Create(district);
            await districtRepository.SaveAsync();
            return Ok(district);
        }
        [HttpGet]
        public IActionResult GetCity()
        {
            var city = _repositoryContext.Cities.Include(x => x.Districts).Select(x => new CityDTO
            {
                CityName = x.CityName,
                Districts = x.Districts
            }).ToList();
            foreach (CityDTO c in city)
            {
                foreach (District d in c.Districts)
                {
                    c.DistrictName.Add(d.DistrictName);
                }
            }
            List<CityShow> _city = new List<CityShow>();
            foreach (CityDTO C in city)
            {
                CityShow o = new CityShow();
                o.CityName = C.CityName;
                o.DisTricts = C.DistrictName;
                _city.Add(o);
            }

            return Ok(_city);
        }
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDTO locationDTO)
        {
            var city = await cityRepository.FindByIdAsync(locationDTO.CityId);
            var district = await districtRepository.FindByIdAsync(locationDTO.DistrictId);
            Address address = new Address();
            address.City = city;
            address.District = district;
            _repositoryContext.Add<Address>(address);
            locationDTO.Address = address;
            var location = _mapper.Map<Location>(locationDTO);
            _repositoryContext.Add<Location>(location);
            await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async  Task<IActionResult> GetAddress()
        {
            var address =   _repositoryContext.Addresses.Include(x => x.District)
                                                             .Include(x => x.City).FirstAsync();
            return Ok(address);
        }
        [HttpGet]
        public async Task<City> FindIdAsync(int id)
        {
            var item = await _repositoryContext.FindAsync<City>(id);
            return item;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity([FromBody]CityDTO _city, int id)
        {
            var City = GetCityById(id);
            await _mapper.Map(_city, City);
           await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetLocation()
        {
            var location = await _repositoryContext.Locations.Include(x => x.Address).Select(x => new LocationDTO
            {
                Name = x.Name,
                City = x.Address.City.CityName,
                District = x.Address.District.DistrictName
            }).FirstAsync();
            return Ok(location);
        }
    }
}
