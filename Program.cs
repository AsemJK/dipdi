

///
//IoC
///
using Microsoft.Extensions.DependencyInjection;
var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<IStudentClient, StudentClient>();
serviceCollection.AddTransient<StudentService>();
///
//End of IoC
///

//Executing
using (var scope = serviceCollection.BuildServiceProvider())
{
    var myService = scope.GetRequiredService<StudentService>();
    Console.WriteLine(myService.GetScore("Asem").ToString());
}

class StudentService
{
    public int Score { get; set; }
    private readonly IStudentClient _studentClient;//DI

    public StudentService(IStudentClient studentClient)//DIP : Upper class (Student Service) depend on Abstraction of lower one(Student Client)
    {
        _studentClient = studentClient;
    }

    public int GetScore(string name)
    {
        return _studentClient.GetScore(name);
    }
}


class StudentClient : IStudentClient
{
    public int GetScore(string name)
    {
        return name.Length;
    }
}

interface IStudentClient
{
    int GetScore(string name);
}