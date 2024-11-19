
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/status", (IConfiguration configuration) =>
{
    if (Random.Shared.Next(0, 2) == 0)
    {
        throw new Exception("Random exception");
    }

    var version = configuration.GetValue<string>("VERSION");
    var message = $"Hello from version '{version}' on '{Environment.MachineName}' at '{DateTime.Now}'";
    return Results.Ok(message);
});

app.Run();