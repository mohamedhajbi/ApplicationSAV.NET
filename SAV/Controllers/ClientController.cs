using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            if (client == null) return BadRequest("Invalid client data.");

            await _clientRepository.AddAsync(client);
            await _clientRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClientById), new { id = client.ClientId }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if (id != client.ClientId) return BadRequest("Client ID mismatch.");

            var existingClient = await _clientRepository.GetByIdAsync(id);
            if (existingClient == null) return NotFound();

            await _clientRepository.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) return NotFound();

            _clientRepository.Delete(client);
            await _clientRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
