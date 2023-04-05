using LittleCash.Api.UseCases;

namespace LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

public class AffiliateCommercialEstablishmentUseCaseRequest: IUseCaseRequest
{
    public string DocumentNumber { get; set; }
}