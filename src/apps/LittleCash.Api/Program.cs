using HealthChecks.UI.Client;
using LittleCash.Api.EndpointRegistrationsByUseCase.Affiliation;
using LittleCash.CrossCutting.Dependencies.Affiliation;
using LittleCash.CrossCutting.Extensions;
using LittleCash.CrossCutting.Options;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var mongoOptions = builder
    .Configuration
    .GetOptionsBySection<MongoDatabaseOptions>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddAffiliateCommercialEstablishmentUseCase();
    
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

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpointsForAffiliateCommercialEstablishmentUseCases();

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });

app.UseHttpsRedirection();

app.Run();