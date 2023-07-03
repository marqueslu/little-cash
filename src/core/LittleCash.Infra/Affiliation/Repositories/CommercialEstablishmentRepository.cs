using System.Linq.Expressions;
using LittleCash.Core.Affiliation.Repositories;
using LittleCash.Core.Entities;
using MongoDB.Driver;

namespace LittleCash.Infra.Affiliation.Repositories;

public class CommercialEstablishmentRepository : ICommercialEstablishmentRepository
{
    private readonly IMongoCollection<CommercialEstablishment> _collection;

    public CommercialEstablishmentRepository(IMongoCollection<CommercialEstablishment> collection)
    {
        _collection = collection;
    }

    public async Task CreateAsync(CommercialEstablishment commercialEstablishment, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(commercialEstablishment, cancellationToken: cancellationToken);
    }

    public async Task<CommercialEstablishment?> GetByDocumentNumberAsync(string documentNumber,
        CancellationToken cancellationToken)
    {
        var filter = FindById(documentNumber);

        var cursor = await _collection.FindAsync(filter, cancellationToken: cancellationToken);

        await cursor.MoveNextAsync(cancellationToken);

        return cursor.Current.FirstOrDefault();
    }

    private static Expression<Func<CommercialEstablishment, bool>> FindById(string documentNumber)
    {
        return (CommercialEstablishment commercialEstablishment) =>
            commercialEstablishment.Document == documentNumber;
    }
}