using Baltazar;
using Baltazar.ContentContext;
using Baltazar.SubscriptionContext;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        var articles = new List<Article>();
        articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));

        var carrers = new List<Career>();
        var careerDotNet = new Career("Especialista .NET", "especialista-dotnet");
        var carrerSqlServer = new Career("Especialista SQL Server", "especialista-sql-server");
        carrers.Add(careerDotNet);
        carrers.Add(carrerSqlServer);

        var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
        var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
        var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");

        var careerItem1 = new CareerItem(3, "Comece por aqui", "", courseAspNet);
        var careerItem2 = new CareerItem(1, "Aprenda OOP", "", courseOOP);
        var careerItem3 = new CareerItem(2, "Aprenda .NET", "", null);

        careerDotNet.CarrerItems.Add(careerItem1);
        careerDotNet.CarrerItems.Add(careerItem2);
        careerDotNet.CarrerItems.Add(careerItem3);

       carrerSqlServer.CarrerItems.Add(new CareerItem(1,"sql master","aprenda",(new Course("fodase","sql"))));
       

       
        foreach(var item in carrers)
        {
            Console.WriteLine(item.Title);
            foreach(var item2 in item.CarrerItems)
            {
                Console.WriteLine($"{item2.Order} - {item2.Title} - {item2.Course?.Title}");
                foreach(var notification in item2.Notification)
                {
                    Console.WriteLine($"{notification.Property} - {notification.Message}");
                }
            }
        }

        Student student = new Student("Baltazar");
        var payPalSubscription = new PaypalSubscription();

        student.CreateSubscription(payPalSubscription);
        Console.WriteLine(student.isPremium);

    }
}
