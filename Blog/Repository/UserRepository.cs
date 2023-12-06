using System.Data.SqlClient;
using blog.Models;
using Dapper.Contrib.Extensions;

namespace blog.Repository
{

    public class UserRepository
    {
     private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        => _connection = connection;


        public User Get(int id)
        => _connection.Get<User>(id);
       

        public IEnumerable<User> readUsers()
        => _connection.GetAll<User>();

    }

}