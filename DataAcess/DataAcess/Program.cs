using System.Data.SqlClient;
using Dapper;

class Program
{
    static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";

        var category = new Category();
        category.Title = "Amazon AWS";
        category.Url = "amazon-aws";
        category.Order = 5;
        category.Description = "Amazon Web Services";
        category.Featured = false;
        category.Summary = "Amazon Web Services";
        category.Id = Guid.NewGuid();

       
        using (var connection = new SqlConnection(connectionString))
        {
         
            insertCategory(connection);
            updateCategory(connection);
            selectCategory(connection);


        }


    }

    static void selectCategory(SqlConnection connection)
    {
        var Categories = connection.Query<Category>("SELECT * FROM Category");
        foreach (var item in Categories)
        {
            System.Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }

    static void insertCategory(SqlConnection connection)
    {
        var insert = @"INSERT INTO [Category] 
                        VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var affectedRows = connection.Execute(insert, new{
            Id = Guid.NewGuid(),
            Title = "Fluttler",
            Url = "Flutter",
            Summary = "Desenvolva aplicativos mobile",
            Order = 5,
            Description = "Flutter é um SDK de código aberto criado pelo Google para desenvolvimento de aplicativos para Android e iOS com uma única base de código.",
            Featured = false
        });

    }

    static void updateCategory(SqlConnection connection)
    {
        var update = @"UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

        var affectedRows = connection.Execute(update, new
        {
            Id = new Guid("b4e7b4a0-3f9c-4e6c-8aee-0e2d3b0e1b4e"),
            Title = "Amazon AWS 2022"
        });

    }    
}
