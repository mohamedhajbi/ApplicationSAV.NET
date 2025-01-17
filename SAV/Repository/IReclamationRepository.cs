using SAV.Models;

namespace SAV.Repository
{
    public interface IReclamationRepository : IRepository<Reclamation>
    {
        Task<IEnumerable<Intervention>> GetInterventionsByReclamationIdAsync(int reclamationId);
    }

}
