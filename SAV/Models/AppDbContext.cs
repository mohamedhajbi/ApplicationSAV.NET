using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAV.Models.Auth;

namespace SAV.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Technicien> Techniciens { get; set; }
        public DbSet<ResponsableSAV> ResponsablesSAV { get; set; }

        public DbSet<Piece> Pieces { get; set; }

        public DbSet<Facture> Factures { get; set; }
        public DbSet<PiecesFacture> PiecesFactures { get; set; }


    }
}
