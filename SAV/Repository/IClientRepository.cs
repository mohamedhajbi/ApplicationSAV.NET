using SAV.Models;

namespace SAV.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Task AddAsync2(Client client);
        Task<IEnumerable<Reclamation>> GetReclamationsByClientIdAsync(int clientId);
    }

}
