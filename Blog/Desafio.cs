
using System.Data.SqlClient;
using blog.Models;
using blog.Repositories;

public class Desafio {
    private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
    public static void Main(string[] args)
    {
        var connection = new SqlConnection(connectionString);
        cadastrarUsuario(connection);

    
        
    }


    public static void cadastrarUsuario(SqlConnection connection)
    {
        var userRepository = new UserRepository(connection);
        var user = new User();
        user.Name = "Carlos";
        user.Email = "carlks@gmail.com";
        user.Slug = "carlos";
        user.PasswordHash = "123456";
        user.Bio = "Carlos";
        user.Image = "carlos.jpg";
        userRepository.Create(user);
        

    }
}



