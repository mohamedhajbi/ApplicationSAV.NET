using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamationController : ControllerBase
    {
        private readonly IReclamationRepository _reclamationRepository;

        public ReclamationController(IReclamationRepository reclamationRepository)
        {
            _reclamationRepository = reclamationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReclamations()
        {
            var reclamations = await _reclamationRepository.GetAllAsync();
            return Ok(reclamations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReclamationById(int id)
        {
            var reclamation = await _reclamationRepository.GetByIdAsync(id);
            if (reclamation == null) return NotFound();
            return Ok(reclamation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReclamation([FromBody] Reclamation reclamation)
        {
            if (reclamation == null) return BadRequest("Invalid reclamation data.");

            await _reclamationRepository.AddAsync(reclamation);
            await _reclamationRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReclamationById), new { id = reclamation.ReclamationId }, reclamation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReclamation(int id, [FromBody] Reclamation reclamation)
        {
            if (id != reclamation.ReclamationId) return BadRequest("Reclamation ID mismatch.");

            var existingReclamation = await _reclamationRepository.GetByIdAsync(id);
            if (existingReclamation == null) return NotFound();

            await _reclamationRepository.UpdateAsync(reclamation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReclamation(int id)
        {
            var reclamation = await _reclamationRepository.GetByIdAsync(id);
            if (reclamation == null) return NotFound();

            _reclamationRepository.Delete(reclamation);
            await _reclamationRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
