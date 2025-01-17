using Microsoft.EntityFrameworkCore;
using SAV.Models;

namespace SAV.Repository
{
    public class ResponsableSAVRepository : Repository<ResponsableSAV>, IResponsableSAVRepository
    {
        private readonly AppDbContext _context;

        public ResponsableSAVRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync2(ResponsableSAV responsable)
        {
            await _context.ResponsablesSAV.AddAsync(responsable);
            await _context.SaveChangesAsync();
        }

       
    }
}
