var builder = WebApplication.CreateBuilder(args);

const string AngularClientPolicy = "_angularClientPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AngularClientPolicy,
                      policy =>
                      {
                          // Angular dev server URL
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddHttpClient();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(AngularClientPolicy);

app.MapGet("/api/rates/daily", async (CnbExchangeRateProvider provider) =>
{
    try
    {
        var rates = await provider.GetDailyRatesAsync();
        return Results.Ok(rates);
    }
    catch (HttpRequestException ex)
    {
        // Error Handling: Catch external API failure and return a Service Unavailable status
        app.Logger.LogError(ex, "Failed to fetch data from CNB.");
        return Results.Problem($"External service error: {ex.Message}", statusCode: 503);
    }
})
.WithName("GetDailyExchangeRates")
.WithOpenApi();

app.Run();