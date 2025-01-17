using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;
using System.Threading.Tasks;

namespace SAV.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicienController : ControllerBase
    {
        private readonly IRepository<Technicien> _technicienRepository;

        public TechnicienController(IRepository<Technicien> technicienRepository)
        {
            _technicienRepository = technicienRepository;
        }

        // GET: api/Technicien
        [HttpGet]
        public async Task<IActionResult> GetAllTechniciens()
        {
            var techniciens = await _technicienRepository.GetAllAsync();
            return Ok(techniciens);
        }

        // GET: api/Technicien/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnicienById(int id)
        {
            var technicien = await _technicienRepository.GetByIdAsync(id);
            if (technicien == null) return NotFound();
            return Ok(technicien);
        }

        // POST: api/Technicien
        [HttpPost]
        public async Task<IActionResult> CreateTechnicien([FromBody] Technicien technicien)
        {
            if (technicien == null) return BadRequest("Les données du technicien sont invalides.");

            await _technicienRepository.AddAsync(technicien);
            await _technicienRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTechnicienById), new { id = technicien.TechnicienId }, technicien);
        }

        // PUT: api/Technicien/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnicien(int id, [FromBody] Technicien technicien)
        {
            if (id != technicien.TechnicienId) return BadRequest("L'ID du technicien ne correspond pas.");
            var existingTechnicien = await _technicienRepository.GetByIdAsync(id);
            if (existingTechnicien == null) return NotFound();

            await _technicienRepository.UpdateAsync(technicien);
            return NoContent();
        }

        // DELETE: api/Technicien/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicien(int id)
        {
            var technicien = await _technicienRepository.GetByIdAsync(id);
            if (technicien == null) return NotFound();

            _technicienRepository.Delete(technicien);
            await _technicienRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
