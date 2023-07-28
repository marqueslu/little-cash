using LittleCash.Core.Entities;

namespace LittleCash.Infra.Repositories;

public static class CollectionNames
{
    private static readonly Dictionary<Type, string> Collections = new()
    {
        { typeof(CommercialEstablishment), "commercialEstablishments" }
    };

    public static string Get<T>() where T : class
    {
        var collectionType = typeof(T);

        if (Collections.TryGetValue(collectionType, out var collectionName) is false)
        {
            throw new InvalidOperationException($"The collection name {collectionType.Name} is unknown type");
        }

        return collectionName;
    }
}