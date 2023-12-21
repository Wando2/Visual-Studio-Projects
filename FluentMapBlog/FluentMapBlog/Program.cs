using FluentMapBlog.Data;
using FluentMapBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FluentMapBlog
{

    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new BlogDataContext();
            
            var posts = context.Posts.Include(p => p.Tags);

            var postsPaginated = GetPosts(context, 0, 10);

            foreach (var post in postsPaginated)
            {
                System.Console.WriteLine(post.Title);
            }




        }

        public static List<Post> GetPosts(BlogDataContext context, int Skip = 0,int  Take = 0)
        {
            return context.Posts
                .Include(p => p.Tags)
                .Skip(Skip)
                .Take(Take)
                .AsNoTracking()
                .ToList();
        }
    }
}