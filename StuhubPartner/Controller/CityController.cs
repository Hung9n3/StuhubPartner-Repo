using System.Collections.Generic;
using System.Threading.Tasks;
using DataObject;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Contracts;
using System.Threading;

namespace StuhubPartner.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private RepositoryContext _repositoryContext;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityController(ICityRepository cityRepository,ILocationRepository locationRepository, IAddressRepository addressRepository, IDistrictRepository districtRepository, RepositoryContext repositoryContext, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _repositoryContext = repositoryContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityRepository.FindAll();
            return Ok(_mapper.Map<IEnumerable<CityDTO>>(cities));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            var city = await _cityRepository.FindByIdAsync(id);
            if (city is null)
                return NotFound();

            return Ok(_mapper.Map<CityDTO>(city));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityDTO _city, CancellationToken cancellationToken = default)
        {
            var city = _mapper.Map<City>(_city);
            _cityRepository.Create(city);
            await _cityRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { city.Id }, _mapper.Map<CityDTO>(city));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CityDTO dto, CancellationToken cancellationToken = default) 
        {
            var city = await _cityRepository.FindByIdAsync(dto.CityID, cancellationToken);
            if (city is null)
                return NotFound();

            _mapper.Map(dto, city);
            await _cityRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(CityDTO dto, CancellationToken cancellationToken = default) 
        {
            var city = await _cityRepository.FindByIdAsync(dto.CityID, cancellationToken);
            if (city is null)
                return NotFound();

            _cityRepository.Delete(city);
            await _cityRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
