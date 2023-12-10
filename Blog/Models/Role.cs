namespace blog.Models
{
    using Dapper.Contrib.Extensions;

    [Table("[Role]")]


    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }

}