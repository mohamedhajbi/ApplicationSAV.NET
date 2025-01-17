using SAV.Models;

namespace SAV.Repository
{
    public interface IResponsableSAVRepository : IRepository<ResponsableSAV>

    {
        Task AddAsync2(ResponsableSAV responsableSAV);
        // Ajoutez d'autres méthodes si nécessaire
    }
}
