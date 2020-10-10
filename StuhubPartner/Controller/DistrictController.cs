using AutoMapper;
using Contracts;
using DataObject;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StuhubPartner.Controller
{
    public class DistrictController : ControllerBase
    {
        private RepositoryContext _repositoryContext;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        public DistrictController(IDistrictRepository districtRepository, RepositoryContext repositoryContext, IMapper mapper) 
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _repositoryContext = repositoryContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var districts = await _districtRepository.FindAll();
            return Ok(_mapper.Map<IEnumerable<DistrictDTO>>(districts));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var district = await _districtRepository.FindByIdAsync(id);
            if (district is null)
                return NotFound();

            return Ok(_mapper.Map<DistrictDTO>(district));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DistrictDTO dto, CancellationToken cancellationToken = default)
        {
            var district = _mapper.Map<District>(dto);
            _districtRepository.Create(district);
            await _districtRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { district.Id }, _mapper.Map<DistrictDTO>(district));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DistrictDTO dto, CancellationToken cancellationToken = default)
        {
            var district = await _districtRepository.FindByIdAsync(dto.id, cancellationToken);
            if (district is null)
                return NotFound();

            _mapper.Map(dto, district);
            await _districtRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(DistrictDTO dto, CancellationToken cancellationToken = default)
        {
            var district = await _districtRepository.FindByIdAsync(dto.id, cancellationToken);
            if (district is null)
                return NotFound();

            _districtRepository.Delete(district);
            await _districtRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
