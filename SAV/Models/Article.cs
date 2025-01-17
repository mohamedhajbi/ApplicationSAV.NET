namespace SAV.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSparePart { get; set; } // Pour distinguer entre articles et pièces de rechange
        
        public ICollection<Intervention>? Interventions { get; set; }
    }

}
