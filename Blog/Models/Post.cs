namespace blog.Models{

    using Dapper.Contrib.Extensions;

    [Table("[Post]")]

    public class Post{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; } 
        public string Content { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
    }
}