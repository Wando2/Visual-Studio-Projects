using blogEntity.Data;
using blogEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace blogEntity
{

    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new BlogDataContext();

         
            var posts = db.Posts.
            AsNoTracking().
            Include(x => x.Author).
            OrderByDescending(x => x.CreateDate).
            ToList();

            foreach (var post in posts)
              Console.WriteLine($"{post.Title} - feito por {post.Author.Name} - {post.CreateDate}");





        }
    }


}
