using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using blog.Models;
using Dapper;

namespace blog.Repositories
{

    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public void linkTag(Post post, Tag tag)
        {
            var sql = @"
                INSERT INTO [PostTag] ([PostId], [TagId])
                VALUES (@PostId, @TagId)
            ";

            _connection.Execute(sql, new { PostId = post.Id, TagId = tag.Id });
        }

        public List<Post> getPostsWithTags()
        {
            var sql = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [Post]
                LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                LEFT JOIN [Tag] ON [Tag].[Id] = [PostTag].[TagId]
            ";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                sql,
                (post, tag) =>
                {
                    var existingPost = posts.FirstOrDefault(p => p.Id == post.Id);

                    if (existingPost == null)
                    {
                        post.Tags = new List<Tag>();
                        posts.Add(post);
                        existingPost = post;
                    }

                    if (tag != null)
                    {
                        existingPost.Tags.Add(tag);
                    }

                    return existingPost;

                },splitOn: "Id");

            return posts;
        }
    }


}
