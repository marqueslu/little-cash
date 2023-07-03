using LittleCash.Core.Entities;

namespace LittleCash.Core.Affiliation.Repositories;

public interface ICommercialEstablishmentRepository
{
    Task CreateAsync(CommercialEstablishment commercialEstablishment, CancellationToken cancellationToke);
    Task<CommercialEstablishment?> GetByDocumentNumberAsync(string documentNumber, CancellationToken cancellationToken);
}