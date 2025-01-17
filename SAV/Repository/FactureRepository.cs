using Microsoft.EntityFrameworkCore;
using SAV.Models;

namespace SAV.Repository
{
    public class FactureRepository : Repository<Facture>, IFactureRepository
    {
        private readonly AppDbContext _context;

        public FactureRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Facture>> GetAllFacturesAsync()
        {
            return await _context.Factures
                .Include(f => f.Intervention) // Optionally include related data
                .Include(f => f.PiecesFacture)
                    .ThenInclude(pf => pf.Piece) // Include related Pieces in PiecesFacture
                .ToListAsync();
        }

        // Method to get a single facture by ID
        public async Task<Facture> GetFactureByIdAsync(int id)
        {
            return await _context.Factures
                .Include(f => f.Intervention) // Optionally include related data
                .Include(f => f.PiecesFacture)
                    .ThenInclude(pf => pf.Piece) // Include related Pieces in PiecesFacture
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task<Facture> CreerFactureAsync(int interventionId, decimal montantMainOeuvre, IEnumerable<(int pieceId, int quantite)> pieces)
        {
            // Retrieve the intervention from the database
            var intervention = await _context.Interventions.FindAsync(interventionId);
            if (intervention == null)
            {
                throw new Exception($"L'intervention avec ID {interventionId} n'existe pas.");
            }

            decimal total = 0;
            var pieceFactureList = new List<PiecesFacture>(); // Declare the list here

            // If the intervention is under warranty
            if (intervention.IsUnderWarranty)
            {
                total = 0; // Invoice total is zero for warranties
            }
            else
            {
                foreach (var pieceInfo in pieces)
                {
                    var piece = await _context.Pieces.FindAsync(pieceInfo.pieceId);
                    if (piece == null)
                    {
                        throw new Exception($"La pièce avec ID {pieceInfo.pieceId} n'existe pas.");
                    }

                    if (piece.Stock < pieceInfo.quantite)
                    {
                        throw new Exception($"Stock insuffisant pour la pièce avec ID {pieceInfo.pieceId} (stock disponible: {piece.Stock}).");
                    }

                    // Add cost of the parts to the total
                    total += piece.Prix * pieceInfo.quantite;

                    // Create PiecesFacture entry
                    pieceFactureList.Add(new PiecesFacture
                    {
                        PieceId = piece.Id,
                        Quantite = pieceInfo.quantite
                    });

                    // Deduct the stock
                    piece.Stock -= pieceInfo.quantite;
                }

                // Add labor cost
                total += montantMainOeuvre;

                // Save the deducted stock changes
                _context.Pieces.UpdateRange(_context.Pieces);
            }

            // Create the facture
            var facture = new Facture
            {
                DateEmission = DateTime.Now,
                InterventionId = interventionId,
                MontantMainOeuvre = intervention.IsUnderWarranty ? 0 : montantMainOeuvre,
                Total = total,
                PiecesFacture = intervention.IsUnderWarranty ? null : pieceFactureList // Now pieceFactureList is accessible here
            };

            // Save the facture to the database
            await _context.Factures.AddAsync(facture);
            await _context.SaveChangesAsync();

            return facture;
        }

       


    }
}
