using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using blog.Models;
using Dapper;

namespace blog.Repositories
{ 
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

        public List<User> GetUsersWithRole()
        {
            var sql = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
            ";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                sql,
                (user, role) =>
                {
                    var existingUser = users.FirstOrDefault(u => u.Id == user.Id);

                    if (existingUser == null)
                    {   
                        user.Roles = new List<Role>();
                        users.Add(user);
                        existingUser = user;
                    }

                    if (role != null)
                    {
                        existingUser.Roles.Add(role);
                    }

                    return existingUser;
                }); 
                

            return users;

        }
        
    }


}