using Microsoft.EntityFrameworkCore;
using SAV.Models;

namespace SAV.Repository
{
    public class ReclamationRepository : Repository<Reclamation>, IReclamationRepository
    {
        private readonly AppDbContext _context;

        public ReclamationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Intervention>> GetInterventionsByReclamationIdAsync(int reclamationId)
        {
            return await _context.Interventions
                                 .Where(i => i.ReclamationId == reclamationId)
                                 .ToListAsync();
        }
    }

}
