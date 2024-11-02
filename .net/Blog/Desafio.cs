
using System.Data.SqlClient;
using blog.Models;
using blog.Repositories;

public class Desafio
{
    private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
    public static void Main(string[] args)
    {
        var connection = new SqlConnection(connectionString);

 
       
        getPostsWithTags(connection);

    }

    public static void linkRole(SqlConnection connection)
    {
        var userRepository = new UserRepository(connection);
        var user = userRepository.Get(1002);
        var roleRepository = new Repository<Role>(connection);
        var role = roleRepository.Get(3);
        userRepository.linkRole(user, role);
    }

    public static void createCategory(SqlConnection connection)
    {
        var categoryRepository = new Repository<Category>(connection);
        var categories = new List<Category>
        {
            new Category { Name = "back-end", Slug = "backend" },
            new Category { Name = "front-end", Slug = "frontend" },
            new Category { Name = "full-stack", Slug = "fullstack" }
        };
        categories.ForEach(category => categoryRepository.Create(category));
    }

    public static void createTag(SqlConnection connection)
    {
        var tagRepository = new Repository<Tag>(connection);

        var tags = new List<Tag>
        {
            new Tag { Name = "C#", Slug = "csharp" },
            new Tag { Name = "Javascript", Slug = "javascript" },
            new Tag { Name = "React", Slug = "react" },
            new Tag { Name = "Angular", Slug = "angular" },
            new Tag { Name = "Vue", Slug = "vue" },
            new Tag { Name = "Node", Slug = "node" },
            new Tag { Name = "SQL", Slug = "sql" }
        };

        tags.ForEach(tag => tagRepository.Create(tag));
    }

    public static void createPost(SqlConnection connection)
    {
        var postRepository = new Repository<Post>(connection);

        var posts = new List<Post>()
        {
            new Post
            {
                Title = "Como criar um blog com React",
                Slug = "como-criar-um-blog-com-react",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi",
                CategoryId = 1,
                AuthorId = 1002,
                Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi"
            },

            new Post
            {
                Title = "Como criar um blog com Angular",
                Slug = "como-criar-um-blog-com-angular",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi",
                CategoryId = 2,
                AuthorId = 1002,
                Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi"
            },

            new Post
            {
                Title = "Como criar um blog com Vue",
                Slug = "como-criar-um-blog-com-vue",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi",
                CategoryId = 3,
                AuthorId = 2,
                Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunc nisl aliquet nunc, vitae aliquam nisi"
            }
        };

        posts.ForEach(post => postRepository.Create(post));
    }

    public static void linkTag(SqlConnection connection)
    {
        var postRepository = new PostRepository(connection);
        var post = postRepository.Get(2);
        var tagRepository = new Repository<Tag>(connection);
        var tag = tagRepository.Get(2);
        postRepository.linkTag(post, tag);
    }

    public static void getPostsWithTags(SqlConnection connection)
    {
        var postRepository = new PostRepository(connection);
        var posts = postRepository.getPostsWithTags();
        posts.ForEach(post =>
        {
            Console.WriteLine(post.Title);
            
            post.Tags.ForEach(tag => Console.WriteLine(tag.Name));
        });
    }
}







