var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

string[] responses = {
    "It is certain", "Without a doubt", "Yes definitely",
    "Most likely", "Outlook good", "Ask again later",
    "Cannot predict now", "Don't count on it", "Very doubtful"
};

app.MapGet("/api/ask", () => 
    TypedResults.Json(new { answer = responses[Random.Shared.Next(responses.Length)] }));

app.Run();
