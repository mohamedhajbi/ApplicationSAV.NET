using System.Text.Json.Serialization;

namespace SAV.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        [JsonIgnore]
        public ICollection<Reclamation>? Reclamations { get; set; }
    }

}
