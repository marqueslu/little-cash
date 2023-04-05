namespace LittleCash.Api.UseCases.Affiliation.AffiliateCommercialEstablishmentUseCase;

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