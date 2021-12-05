using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrionProject.Core.DTOs;
using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clients = await _clientService.GetClients();
            var clientsDTO = _mapper.Map<List<ClientDTO>>(clients);
            return Ok(clientsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var client = await _clientService.GetClient(id);
            if (client == null) return NotFound();
            var clientDTO = _mapper.Map<ClientDTO>(client);
            return Ok(clientDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var client = _mapper.Map<Client>(clientDTO);
            await _clientService.AddClient(client);
            return Created(nameof(Get), new { id = client.Id, clientDTO });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientDTO clientDTO)
        {
            if (id != clientDTO.Id || !ModelState.IsValid) return BadRequest();
            clientDTO.Id = id;
            var client = _mapper.Map<Client>(clientDTO);
            await _clientService.UpdateClient(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            await _clientService.DeleteClient(id.Value);
            return NoContent();
        }
    }
}
