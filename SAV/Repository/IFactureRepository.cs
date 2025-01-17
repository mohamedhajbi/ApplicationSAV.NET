using SAV.Models;

namespace SAV.Repository
{
    public interface IFactureRepository : IRepository<Facture>
    {
        Task<IEnumerable<Facture>> GetAllFacturesAsync();
        Task<Facture> GetFactureByIdAsync(int id);

        Task<Facture> CreerFactureAsync(int interventionId, decimal montantMainOeuvre, IEnumerable<(int pieceId, int quantite)> pieces);
    }
}
