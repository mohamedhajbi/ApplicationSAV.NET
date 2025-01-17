namespace SAV.Models
{
    public class Technicien
    {
        public int TechnicienId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Intervention>? Interventions { get; set; }
    }

}
