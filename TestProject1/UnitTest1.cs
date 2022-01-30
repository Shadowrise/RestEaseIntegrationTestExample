using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RestEase;
using Xunit;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public async Task Test_Greeting()
    {
        // arrange
        var greeting = "Hello from test instance of web service";
        var greaterMock = Mock.Of<IGreater>(o => o.GetGreeting() == greeting);
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IGreater>(x => greaterMock);
            });
        });
        var restEaseClient = RestClient.For<IClient>(factory.CreateClient());
        
        // act
        var result = await restEaseClient.GetGreeting();
        
        // assert
        Assert.Equal(greeting, result);
    }
}