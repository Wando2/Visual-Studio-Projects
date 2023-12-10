
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

public class Repository <T> where T : class
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
    => _connection = connection;

    public T Get(int id)
    => _connection.Get<T>(id);

    public IEnumerable<T> read()
    => _connection.GetAll<T>();

    public void Create(T entity)
    => _connection.Insert(entity);

    public void Update(T entity)
    => _connection.Update(entity);

    public void Delete(T entity)
    => _connection.Delete(entity);
}