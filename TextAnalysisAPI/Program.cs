using TextAnalysisAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Register TextAnalysisService
builder.Services.AddSingleton<TextAnalysisService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Test anfrage via get
//http://localhost:3000/countWords?input=das ist ein Test den test test&words=test






// Endpoint zum Zählen von Wörtern
app.MapGet("/countWords", (TextAnalysisService service, string input, string[] words) =>
{
    return Results.Json(new { Count = service.CountWords(input, words) });
});

// Endpoint zum Überprüfen, ob Wörter enthalten sind
app.MapGet("/containsWords", (TextAnalysisService service, string input, string[] words) =>
{
    return Results.Json(new { Contains = service.ContainsWords(input, words) });
});

// Endpoint zum Zählen von Buchstaben
app.MapGet("/countLetters", (TextAnalysisService service, string input, char[] letters) =>
{
    return Results.Json(new { Count = service.CountLetters(input, letters) });
});

// Endpoint zum Überprüfen, ob Buchstaben enthalten sind
app.MapGet("/containsLetters", (TextAnalysisService service, string input, char[] letters) =>
{
    return Results.Json(new { Contains = service.ContainsLetters(input, letters) });
});

// Endpoint zum Überprüfen, ob ein String Base64-kodiert ist
app.MapGet("/isBase64", (TextAnalysisService service, string input) =>
{
    return Results.Json(new { IsBase64 = service.IsBase64String(input) });
});

// Endpoint zum Überprüfen, ob eine E-Mail-Adresse valide ist
app.MapGet("/isValidEmail", (TextAnalysisService service, string input) =>
{
    return Results.Json(new { IsValidEmail = service.IsValidEmail(input) });
});

// Endpoint zum Konvertieren eines Strings in einen Dezimalwert
app.MapGet("/convertStringToDecimal", (TextAnalysisService service, string input) =>
{
    return Results.Json(new { DecimalValue = service.ConvertStringToDecimal(input) });
});


app.Run();
