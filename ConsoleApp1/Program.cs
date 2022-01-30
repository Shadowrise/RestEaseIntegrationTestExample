// See https://aka.ms/new-console-template for more information

using ClassLibrary1;
using RestEase;

var client = RestClient.For<IClient>("https://localhost:5000");
Console.WriteLine($"From client: {await client.GetGreeting()}");
Console.ReadKey();


    