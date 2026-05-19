using DistanceApi.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDistanceCalculator, DistanceCalculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// https://localhost:7170/swagger
// GET /api/distance?lat1=55.75&lon1=37.61&lat2=59.93&lon2=30.33
// https://localhost:7170/api/distance?lat1=55.75&lon1=37.61&lat2=59.93&lon2=30.33

/*
    lat1 = 55.75
    lon1 = 37.61
    lat2 = 59.93
    lon2 = 30.33
 */