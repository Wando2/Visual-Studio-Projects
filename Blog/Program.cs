
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


    public void GetUser(int id, SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);
        var user = UserRepository.Get(id);
        Console.WriteLine(user.Name);
    }

    public void GetUsers(SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);
        var users = UserRepository.readUsers();
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }


    public void getUsers2(SqlConnection connection)
    {
        var userRepository = new Repository<User>(connection);
        var users = userRepository.read();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

}