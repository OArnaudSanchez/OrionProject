using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrionProject.Core.DTOs;
using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressesController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var addresses = await _addressService.GetAddresses();
            var addressesDTO = _mapper.Map<List<AddressDTO>>(addresses);
            return Ok(addressesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var address = await _addressService.GetAddress(id);
            if (address == null) return NotFound();
            var addressDTO = _mapper.Map<AddressDTO>(address);
            return Ok(addressDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddressDTO addressDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var address = _mapper.Map<Address>(addressDTO);
            await _addressService.AddAddress(address);
            return Created(nameof(Get), new { id = address.Id, addressDTO });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddressDTO addressDTO)
        {
            if (id != addressDTO.Id || !ModelState.IsValid) return BadRequest();
            addressDTO.Id = id;
            var address = _mapper.Map<Address>(addressDTO);
            await _addressService.UpdateAddress(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            await _addressService.DeleteAddress(id.Value);
            return NoContent();
        }
    }
}
