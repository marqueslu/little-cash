using LittleCash.Api.UseCases;

namespace LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

public class AffiliateCommercialEstablishmentUseCase : IUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
    AffiliateCommercialEstablishmentUseCaseResponse>    
{
    public Task<AffiliateCommercialEstablishmentUseCaseResponse> ExecuteAsync(
        AffiliateCommercialEstablishmentUseCaseRequest request)
    {
        return Task.FromResult(new AffiliateCommercialEstablishmentUseCaseResponse
        {
            Teste = 1
        });
    }
}