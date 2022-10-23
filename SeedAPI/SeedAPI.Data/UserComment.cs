namespace SeedAPI.Data
{
    public class UserComment
    {
        public int Id { get; set; }

        public int UserPostId { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

        public int UserId { get; set; }
        
        public string Status { get; set; }
        
        public string Comment { get; set; }
    }
}