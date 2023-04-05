using HealthChecks.UI.Client;
using LittleCash.CrossCutting.Extensions;
using LittleCash.CrossCutting.Options;
using DiagnosticHealthCheck = Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);
var mongoOptions = builder.Configuration.GetOptionsBySection<MongoDatabaseOptions>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecksUI().AddInMemoryStorage();
builder.Services.AddHealthChecks().AddMongoDb(mongoOptions.ConnectionString, mongoOptions.DatabaseName,
    failureStatus: HealthStatus.Unhealthy, tags: new String[] { "database", "mongo" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health", new DiagnosticHealthCheck.HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    })
    .UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();