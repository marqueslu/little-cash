using LittleCash.Api.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

public static class AffiliateCommercialEstablishmentUseCaseConfigurations
{
    public static void AddAffiliateCommercialEstablishmentUseCase(this IServiceCollection collection)
    {
        collection
            .TryAddScoped<IUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
            AffiliateCommercialEstablishmentUseCaseResponse>, AffiliateCommercialEstablishmentUseCase>();
    }
}