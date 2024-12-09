var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/ask", () => {
    string[] responses = {
        "It is certain", "Without a doubt", "Yes definitely",
        "Most likely", "Outlook good", "Ask again later",
        "Cannot predict now", "Don't count on it", "Very doubtful"
    };
    return Results.Json(new { answer = responses[Random.Shared.Next(responses.Length)] });
});

app.Run();
