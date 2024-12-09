var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

string[] responses = {
    "It is certain", "Without a doubt", "Yes definitely",
    "Most likely", "Outlook good", "Ask again later",
    "Cannot predict now", "Don't count on it", "Very doubtful"
};

// API endpoint
app.MapGet("/api/ask", () => 
    TypedResults.Json(new { answer = responses[Random.Shared.Next(responses.Length)] }));

// Catch-all route to serve index.html
app.MapFallbackToFile("index.html");

app.Run();
