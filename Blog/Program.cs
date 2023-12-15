
using System.Data.SqlClient;
using blog.Models;
using blog.Repositories;

class Program
{
    private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

    public static void getUsersWithRole(SqlConnection connection)
    {
        var userRepository = new UserRepository(connection);
        var users = userRepository.GetUsersWithRole();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
            
            foreach (var role in user.Roles)
            {
                Console.WriteLine(role.Name);
            }
        }
    }


}