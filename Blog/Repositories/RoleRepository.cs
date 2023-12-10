
using System.Data.SqlClient;
using blog.Models;
using Dapper.Contrib.Extensions;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
    => _connection = connection;


    public Role Get(int id)
    => _connection.Get<Role>(id);

    public IEnumerable<Role> readRoles()
    => _connection.GetAll<Role>();

    public void Create(Role role)
    => _connection.Insert(role);

    

}
