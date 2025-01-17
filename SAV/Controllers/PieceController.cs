using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class PieceController : ControllerBase
    {
        private readonly IPieceRepository _pieceRepository;

        public PieceController(IPieceRepository pieceRepository)
        {
            _pieceRepository = pieceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piece>>> GetAllPieces()
        {
            var pieces = await _pieceRepository.GetAllAsync();
            return Ok(pieces);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePiece([FromBody] Piece piece)
        {
            await _pieceRepository.AddAsync(piece);
            await _pieceRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllPieces), new { id = piece.Id }, piece);
        }
    }
}
