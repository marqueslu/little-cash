using LittleCash.Core.Settings;
using LittleCash.Core.Shared.SeedWork;
using LittleCash.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace LittleCash.Infra.Extensions;

public static class ConfigurationMongoRepositoriesExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var (client, mongoUrl) = GetMongoClient(configuration);
        var db = client.GetDatabase(mongoUrl.DatabaseName);
    
        services.AddSingleton<IMongoClient>(x => client);
        services.AddSingleton<IMongoDatabase>(x => db);
    
        if (BsonSerializer.LookupSerializer(typeof(Guid)) == null)
        {
            BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));
        }
    
        ConfigurePackConvention();
    
        return services;
    }
    
    public static IServiceCollection TryAddMongoCollection<T>(this IServiceCollection service)
        where T : Entity
    {
        service.TryAddScoped(serviceProvider =>
        {
            var db = serviceProvider.GetRequiredService<IMongoDatabase>();
            return db.GetCollection<T>(CollectionNames.Get<T>());
        });
    
        return service;
    }
    
    private static void ConfigurePackConvention()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new EnumRepresentationConvention(BsonType.String)
        };
    
        ConventionRegistry.Register("", pack, t => true);
    }
    
    private static (MongoClient, MongoUrl) GetMongoClient(IConfiguration configuration)
    {
        var settings = configuration.GetSettingsBySection<MongoDbSettings>(sectionName: "MongoDb");
    
        var mongoUrl = MongoUrl.Create(settings.ConnectionString);
    
        var clientSettings = MongoClientSettings.FromUrl(mongoUrl);

        var client = new MongoClient(clientSettings);
    
        return (client, mongoUrl);
    }
}