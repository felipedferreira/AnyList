using AnyList.WebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// NOTE TO SELF - this should be done as a part of the application layer not the API layer
builder.Services.AddQueryServices();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", (CancellationToken cancellationToken, IQueryService queryService) =>
    {
        // example of IoC - commenting out as there is no need to call this right now
        // queryService.ConnectAsync();
        
        var randomForecasts = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55)
                ))
            .ToArray();
        return randomForecasts;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

