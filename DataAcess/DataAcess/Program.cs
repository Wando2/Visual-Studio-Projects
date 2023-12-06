using System.Data;
using System.Data.SqlClient;
using Dapper;

class Program
{
    static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";



        using (var connection = new SqlConnection(connectionString))
        {

            //insertCategory(connection);
            //updateCategory(connection);
            // storedProcedure(connection);
            //insertManyCategory(connection);
            // selectCategory(connection);
            //executeScalar(connection);
            //selectView(connection);
            //OneToOne(connection);
            //OneToMany(connection);
            selectIn(connection);
        }


    }

    static void insertManyCategory(SqlConnection connection)
    {
        var insert = @"INSERT INTO [Category] 
                        VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var category2 = new Category();
        category2.Title = "Amazon AWS 2";
        category2.Url = "amazon-aws-2";
        category2.Order = 5;
        category2.Description = "Amazon Web Services 2";
        category2.Featured = false;
        category2.Summary = "Amazon Web Services 2";
        category2.Id = Guid.NewGuid();

        var category3 = new Category();
        category3.Title = "Kotlin";
        category3.Url = "kotlin";
        category3.Order = 5;
        category3.Description = "Kotlin";
        category3.Featured = false;
        category3.Summary = "Kotlin";
        category3.Id = Guid.NewGuid();

        var affectedRows = connection.Execute(insert, new[]{
            category2,
            category3
        });

        Console.WriteLine($"{affectedRows} linhas inseridas");
    }

    static void storedProcedure(SqlConnection connection)
    {
        var procedure = "deleteStudent";
        var parameters = new { StudentId = new Guid("b4e7b4a0-3f9c-4e6c-8aee-0e2d3b0e1b4e") };

        var affectedRows = connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
        Console.WriteLine($"{affectedRows} linhas afetadas");
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

        var affectedRows = connection.Execute(insert, new
        {
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

    static void executeScalar(SqlConnection connection)
    {
        var insert = @"INSERT INTO [Category] 
                        OUTPUT INSERTED.[Id]
                        VALUES (NEW7jID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var id = connection.ExecuteScalar<Guid>(insert, new
        {
            Title = "Amazon AWS 2024",
            Url = "amazon-aws-2024",
            Summary = "Amazon Web Services 2024",
            Order = 5,
            Description = "Amazon Web Services 2024",
            Featured = false

        });

        Console.WriteLine(id);

    }

    static void selectView(SqlConnection connection)
    {
        var sql = @"SELECT * FROM [vwCareer]";

        var courses = connection.Query(sql);

        foreach (var item in courses)
        {
            System.Console.WriteLine($"{item.CareerID} - {item.Title} - {item.Description}");
        }


    }

    static void OneToOne(SqlConnection connection)
    {
        var sql = "SELECT * FROM [CareerItem] ci INNER JOIN [course] c ON ci.[courseId] = c.[Id]";

        var careers = connection.Query<CareerItem, course, CareerItem>(sql,
            (career, course) =>
            {
                career.Course = course;
                return career;
            }, splitOn: "Id");


        foreach (var item in careers)
        {
            System.Console.WriteLine($"{item.Course.Id} - {item.Title} - {item.Course.Title}");
        }
    }

    static void OneToMany(SqlConnection connection)
    {
        var sql = @"SELECT [Career].Id, [Career].[Title], [CareerItem].CareerId, [CareerItem].[Title]
                    FROM [Career]
                    INNER JOIN [CareerItem] ON [CareerItem].CareerId = [Career].Id
                    ORDER BY [Career].[Title]";

        var careers = new List<Career>();
        var items = connection.Query<Career, CareerItem, Career>(sql,
            (career, item) =>
            {
                var _career = careers.FirstOrDefault(x => x.Id == career.Id);
                if (_career == null)
                {
                    _career = career;
                    careers.Add(_career);
                }
                else
                {
                    _career.Items.Add(item);
                }

                return _career;
            }, splitOn: "CareerId");

        foreach (var item in careers)
        {
            System.Console.WriteLine($"{item.Id} - {item.Title}");
            foreach (var subitem in item.Items)
            {
                System.Console.WriteLine($"{subitem.Title}");
            }
        }

    }

    static void selectIn(SqlConnection connection)
    {
        var sql = @"SELECT * FROM [Career] WHERE [Id] IN @Ids";

        var categories = connection.Query<Career>(sql, new
        {
            Ids = new[] {  "4327ac7e-963b-4893-9f31-9a3b28a4e72b",
                           "01ae8a85-b4e8-4194-a0f1-1c6190af54cb" }
        });

        foreach (var item in categories)
        {
            System.Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }

}


