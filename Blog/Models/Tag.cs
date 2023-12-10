namespace blog.Models
{
    using Dapper.Contrib.Extensions;

    [Table("[Tag]")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; } 
    }
}
