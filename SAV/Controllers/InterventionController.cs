using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly IRepository<Intervention> _interventionRepository;

        public InterventionController(IRepository<Intervention> interventionRepository)
        {
            _interventionRepository = interventionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterventions()
        {
            var interventions = await _interventionRepository.GetAllAsync();
            return Ok(interventions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterventionById(int id)
        {
            var intervention = await _interventionRepository.GetByIdAsync(id);
            if (intervention == null) return NotFound();
            return Ok(intervention);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIntervention([FromBody] Intervention intervention)
        {
            if (intervention == null) return BadRequest("Invalid intervention data.");

            await _interventionRepository.AddAsync(intervention);
            await _interventionRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInterventionById), new { id = intervention.InterventionId }, intervention);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIntervention(int id, [FromBody] Intervention intervention)
        {
            if (id != intervention.InterventionId) return BadRequest("Intervention ID mismatch.");

            var existingIntervention = await _interventionRepository.GetByIdAsync(id);
            if (existingIntervention == null) return NotFound();

            await _interventionRepository.UpdateAsync(intervention);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention(int id)
        {
            var intervention = await _interventionRepository.GetByIdAsync(id);
            if (intervention == null) return NotFound();

            _interventionRepository.Delete(intervention);
            await _interventionRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
