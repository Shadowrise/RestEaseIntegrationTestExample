using RestEase;

namespace ClassLibrary1;

public interface IClient
{
    [Get("/greeting")]
    Task<string> GetGreeting();
}

public interface IGreater
{
    string GetGreeting();
}

public class Greater : IGreater
{
    public string GetGreeting()
    {
        return "Hello from web service";
    }
}