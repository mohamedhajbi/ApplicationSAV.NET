namespace SAV.Models
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        public DateTime DateIntervention { get; set; }
        public bool IsUnderWarranty { get; set; }
        public decimal TotalCost { get; set; } // Si hors garantie
        public int ReclamationId { get; set; }
        public Reclamation? Reclamation { get; set; }
        public int TechnicienId { get; set; }
        public Technicien? Technicien { get; set; }
        public ICollection<Article>? ArticlesUsed { get; set; }
    }

}
