
using System.Data.SqlClient;
using blog.Models;
using blog.Repository;
using Dapper.Contrib.Extensions;

class Program
{
    private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
    static void Main(string[] args)
    {
        var connection = new SqlConnection(connectionString);


      
    }


    public void  GetUser(int id, SqlConnection connection)
    {
       var UserRepository = new UserRepository(connection);
         var user = UserRepository.Get(id);
         Console.WriteLine(user.Name);
    }
   
   

    public static void createUser()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var user = new User
            {
                Name = "Paulin",
                Email = "paulin@gmail.com",
                PasswordHash = "123456",
                Bio = "I am a developer",
                Image = "https://static.productionready.io/images/smiley-cyrus.jpg",
                Slug = "paulin"
            };

            connection.Insert(user);
        }
    }

    public static void updateUser()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var user = connection.Get<User>(1);
            user.Name = "Joaozim";
            connection.Update(user);
        }    
    }

    public static void deleteUser()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var user = connection.Get<User>(1);
            connection.Delete(user);
        }    
    }
}