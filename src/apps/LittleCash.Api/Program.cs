using HealthChecks.UI.Client;
using LittleCash.CrossCutting.Extensions;
using LittleCash.CrossCutting.Options;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var mongoOptions = builder
    .Configuration
    .GetOptionsBySection<MongoDatabaseOptions>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHealthChecks()
    .AddMongoDb(
        mongodbConnectionString: mongoOptions.ConnectionString,
        name: mongoOptions.DatabaseName,
        failureStatus: HealthStatus.Unhealthy,
        tags: new[] { "database", "mongo" }, TimeSpan.FromSeconds(1));

builder.Services
    .AddHealthChecksUI(opt =>
    {
        opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
        opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
        opt.SetApiMaxActiveRequests(1); //api requests concurrency
        opt.AddHealthCheckEndpoint("Little Cash Api", "/health");
    })
    .AddInMemoryStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    })
    .UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();