using LittleCash.Core.Affiliation.Repositories;
using LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;
using LittleCash.Core.Shared.UseCases;
using LittleCash.Infra.Affiliation.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LittleCash.CrossCutting.Dependencies.Affiliation;

public static class AffiliateCommercialEstablishmentUseCaseConfigurations
{
    public static void AddAffiliateCommercialEstablishmentUseCase(this IServiceCollection collection)
    {
        collection
            .TryAddScoped<IUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
                AffiliateCommercialEstablishmentUseCaseResponse>, AffiliateCommercialEstablishmentUseCase>();
        collection.TryAddScoped<ICommercialEstablishmentRepository, CommercialEstablishmentRepository>();
    }
}