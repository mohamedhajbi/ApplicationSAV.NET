using Microsoft.EntityFrameworkCore;
using SAV.Models;

namespace SAV.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync2(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Reclamation>> GetReclamationsByClientIdAsync(int clientId)
        {
            return await _context.Reclamations
                                 .Where(r => r.ClientId == clientId)
                                 .ToListAsync();
        }
    }

}
