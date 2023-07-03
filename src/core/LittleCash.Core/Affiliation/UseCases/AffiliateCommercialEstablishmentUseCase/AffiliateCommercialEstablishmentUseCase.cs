using LittleCash.Api.Exceptions;
using LittleCash.Core.Affiliation.Repositories;
using LittleCash.Core.Entities;
using LittleCash.Core.Shared.UseCases;

namespace LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

public class AffiliateCommercialEstablishmentUseCase : IUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
    AffiliateCommercialEstablishmentUseCaseResponse>
{
    private readonly ICommercialEstablishmentRepository _commercialEstablishmentRepository;

    public AffiliateCommercialEstablishmentUseCase(ICommercialEstablishmentRepository commercialEstablishmentRepository)
    {
        _commercialEstablishmentRepository = commercialEstablishmentRepository;
    }

    public async Task<AffiliateCommercialEstablishmentUseCaseResponse> ExecuteAsync(
        AffiliateCommercialEstablishmentUseCaseRequest request, CancellationToken cancellationToken)
    {
        var existentCommercialEstablishment =
            await _commercialEstablishmentRepository.GetByDocumentNumberAsync(request.Document, cancellationToken);

        if (existentCommercialEstablishment is not null)
            throw new ConflictException("Already exists a commercial establishment with this document");

        var commercialEstablishment =
            new CommercialEstablishment(request.Name, request.Document, request.PaymentScheme, request.Domicile);

        await _commercialEstablishmentRepository.CreateAsync(commercialEstablishment, cancellationToken);

        return new AffiliateCommercialEstablishmentUseCaseResponse
        {
            Success = true
        };
    }
}