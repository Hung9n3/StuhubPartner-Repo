using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataObject;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Threading;
using DataObject.LocationPost;

namespace StuhubPartner.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartnerLocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityRepository _cityRepository;
        private RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;
        public PartnerLocationController(ILocationRepository locationRepository, ICityRepository cityRepository, IDistrictRepository districtRepository, RepositoryContext repositoryContext, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _mapper = mapper;
            _repositoryContext = repositoryContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var location = await _locationRepository.FindAll();
            return Ok(_mapper.Map<LocationDTO>(location));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellation = default)
        {
            var location = await _locationRepository.FindByIdAsync(id,cancellation);
            if (location is null) return NotFound();
            var _location = _mapper.Map<LocationDTO>(location);
            return Ok(_location);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LocationPost _location, CancellationToken cancellationToken = default)
        {
            var address = _mapper.Map<Address>(_location);
            _repositoryContext.Addresses.Add(address);
            _location.Address = address;
            var location = _mapper.Map<Location>(_location);
            _locationRepository.Create(location);
            await _locationRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { location.Id }, _mapper.Map<LocationDTO>(location));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(LocationPost _locationDTO, int id, CancellationToken cancellation = default)
        {
            var location = await _locationRepository.FindByIdAsync(id, cancellation);
            _mapper.Map(_locationDTO, location.Address);
            _repositoryContext.Addresses.Update(location.Address);
            if ( location is null)
                    return NotFound();
             _mapper.Map(_locationDTO, location);
            _repositoryContext.Locations.Update(location);
            await _locationRepository.SaveChangesAsync(cancellation);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var location = await _locationRepository.FindByIdAsync(id);
            var address = location.Address;
            _repositoryContext.Addresses.Remove(address);
            _repositoryContext.Locations.Remove(location);
           await _repositoryContext.SaveChangesAsync();
            return Ok();
        }
    }
}
