namespace SeedAPI.Data
{
    public class UserPost
    {
        public int Id { get; set; }

        public int RevisionId { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }
        
        public string Language { get; set; }
        
        public int UserId { get; set; }
        
        public string Status { get; set; }
        
        public string Title { get; set; }
        
        public string[] Tags { get; set; }
        
        public string Content { get; set; }
    }
}