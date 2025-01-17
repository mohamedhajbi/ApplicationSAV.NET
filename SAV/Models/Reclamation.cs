namespace SAV.Models
{
    public class Reclamation
    {
        public int ReclamationId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; } // Ex: "En attente", "En cours", "Terminée"
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<Intervention>? Interventions { get; set; }
    }

}
