using LittleCash.Core.Affiliation.ValueObjects;
using LittleCash.Core.Shared.UseCases;

namespace LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

public class AffiliateCommercialEstablishmentUseCaseRequest : IUseCaseRequest
{
    public string Name { get; set; }
    public string Document { get; set; }
    public PaymentScheme PaymentScheme { get; set; }
    public Domicile Domicile { get; set; }
}