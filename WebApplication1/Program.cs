using ClassLibrary1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IGreater, Greater>();
var app = builder.Build();

app.MapGet("/greeting", (IGreater greater) => greater.GetGreeting());

app.Run();