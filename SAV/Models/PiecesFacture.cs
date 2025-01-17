using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SAV.Models
{
    public class PiecesFacture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FactureId { get; set; }
        [JsonIgnore]
        public Facture? Facture { get; set; }

        [Required]
        public int PieceId { get; set; }
        public Piece? Piece { get; set; }

        [Required]
        public int Quantite { get; set; }

    }
}
