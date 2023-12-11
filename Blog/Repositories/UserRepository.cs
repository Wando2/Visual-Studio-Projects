using System.Data.SqlClient;
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
                    var usr = users.FirstOrDefault(u => u.Id == user.Id);

                    if (usr == null)
                    {
                        users.Add(user);
                        usr = user;
                    }
                    else 
                      usr.Roles.Add(role);

                    return usr;  
                },

            return users;

        }
        
    }


}