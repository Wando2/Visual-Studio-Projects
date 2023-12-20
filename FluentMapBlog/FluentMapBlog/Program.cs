using FluentMapBlog.Data;
using FluentMapBlog.Models;

namespace FluentMapBlog
{

    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            context.Users.Add(new User
            {
                Name = "John Doe",
                Email = "jj@gmail.com",
                Slug = "john-doe",
                Bio = "I am John Doe",
                Image = "https://www.google.com",
                PasswordHash = "123456"
            });

            context.SaveChanges();

           
            
        }
    }
}