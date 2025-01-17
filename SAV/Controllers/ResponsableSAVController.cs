using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace SAV.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsableSAVController : ControllerBase
    {
        private readonly IRepository<ResponsableSAV> _repository;

        public ResponsableSAVController(IRepository<ResponsableSAV> repository)
        {
            _repository = repository;
        }

        // GET: api/ResponsableSAV
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsableSAV>>> GetAll()
        {
            var responsables = await _repository.GetAllAsync();
            return Ok(responsables);
        }

        // GET: api/ResponsableSAV/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsableSAV>> GetById(int id)
        {
            var responsable = await _repository.GetByIdAsync(id);
            if (responsable == null)
            {
                return NotFound($"ResponsableSAV with ID {id} not found.");
            }
            return Ok(responsable);
        }

        // POST: api/ResponsableSAV
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ResponsableSAV responsable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(responsable);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = responsable.ResponsableSAVId }, responsable);
        }

        // PUT: api/ResponsableSAV/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ResponsableSAV responsable)
        {
            if (id != responsable.ResponsableSAVId)
            {
                return BadRequest("ID mismatch.");
            }

            var existingResponsable = await _repository.GetByIdAsync(id);
            if (existingResponsable == null)
            {
                return NotFound($"ResponsableSAV with ID {id} not found.");
            }

            await _repository.UpdateAsync(responsable);
            return NoContent();
        }

        // DELETE: api/ResponsableSAV/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var responsable = await _repository.GetByIdAsync(id);
            if (responsable == null)
            {
                return NotFound($"ResponsableSAV with ID {id} not found.");
            }

            _repository.Delete(responsable);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
