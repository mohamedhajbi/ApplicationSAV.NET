using SAV.Models;

namespace SAV.Repository
{
    public interface IPieceRepository : IRepository<Piece>
    {
        Task<bool> VerifierStockAsync(int pieceId, int quantite);
        Task DeductStockAsync(int pieceId, int quantite);
    }
}
