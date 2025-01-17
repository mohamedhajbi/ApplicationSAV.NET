using Microsoft.EntityFrameworkCore;
using SAV.Models;

namespace SAV.Repository
{
    public class PieceRepository : Repository<Piece>, IPieceRepository
    {
        private readonly AppDbContext _context;

        public PieceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> VerifierStockAsync(int pieceId, int quantite)
        {
            var piece = await _context.Pieces.FindAsync(pieceId);
            return piece != null && piece.Stock >= quantite;
        }

        public async Task DeductStockAsync(int pieceId, int quantite)
        {
            var piece = await _context.Pieces.FindAsync(pieceId);
            if (piece != null)
            {
                piece.Stock -= quantite;
                _context.Pieces.Update(piece);
                await _context.SaveChangesAsync();
            }
        }
    }
}
