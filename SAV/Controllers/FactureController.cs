using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.DTO;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly IFactureRepository _factureRepository;

        public FactureController(IFactureRepository factureRepository)
        {
            _factureRepository = factureRepository;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetAllFactures()
        {
            var factures = await _factureRepository.GetAllFacturesAsync();
            return Ok(factures);
        }

        // GET: api/Facture/{id}
        [Authorize(Roles = "Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Facture>> GetFactureById(int id)
        {
            var facture = await _factureRepository.GetFactureByIdAsync(id);

            if (facture == null)
            {
                return NotFound($"La facture avec ID {id} n'existe pas.");
            }

            return Ok(facture);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult<Facture>> CreerFacture(
     int interventionId,
     decimal montantMainOeuvre,
     [FromBody] List<PieceDto> pieces)
        {
            if (pieces == null || !pieces.Any())
            {
                return BadRequest("La liste des pièces ne peut pas être vide.");
            }

            try
            {
                // Convert DTO to tuple for repository method
                var pieceData = pieces.Select(p => (p.PieceId, p.Quantite));
                var facture = await _factureRepository.CreerFactureAsync(interventionId, montantMainOeuvre, pieceData);
                return Ok(facture);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


    }
}
