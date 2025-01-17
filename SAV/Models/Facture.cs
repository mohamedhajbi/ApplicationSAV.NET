using System.ComponentModel.DataAnnotations;

namespace SAV.Models
{
    public class Facture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateEmission { get; set; }

        [Required]
        public int InterventionId { get; set; }
        public Intervention? Intervention { get; set; }

        public ICollection<PiecesFacture>? PiecesFacture { get; set; }

        [Required]
        public decimal MontantMainOeuvre { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}
