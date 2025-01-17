using System.ComponentModel.DataAnnotations;

namespace SAV.Models
{
    public class Piece
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public decimal Prix { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
