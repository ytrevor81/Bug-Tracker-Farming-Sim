using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
// app.MapGet("/weatherforecast", () =>
// {
    // var forecast =  Enumerable.Range(1, 5).Select(index =>
        // new WeatherForecast
        // (
            // DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            // Random.Shared.Next(-20, 55),
            // summaries[Random.Shared.Next(summaries.Length)]
        // ))
        // .ToArray();
    // return forecast;
// })
// .WithName("GetWeatherForecast");
