namespace blog.Models{

    using Dapper.Contrib.Extensions;

    [Table("[Post]")]

    public class Post{

        public Post()
            => new List<Tag>();

        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public string Summary { get; set; }
        

        [Write(false)]
        
        public List<Tag> Tags { get; set; }

    }
}