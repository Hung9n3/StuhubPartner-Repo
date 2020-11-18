using AutoMapper;
using Contracts.SmartZoneInterfaces.Interfaces;
using DataObject.SmartZone.SmartZone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuhubPartner.Controller
{
    [Route("api/access")]
    [ApiController]
    public class SmartZoneController : BaseController
    {
        private readonly ISmartZoneRepository _smartZoneRepository;
        private readonly IMapper _mapper;
        public SmartZoneController(ISmartZoneRepository smartZoneRepository, IMapper mapper)
        {
            _smartZoneRepository = smartZoneRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var smartzones = await _smartZoneRepository.FindAll().AsNoTracking().ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SmartZoneDTO>>(smartzones));
        }
    }
}
