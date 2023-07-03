using LittleCash.Core.Affiliation.UseCases.AffiliateCommercialEstablishmentUseCase;

namespace LittleCash.Api.EndpointRegistrationsByUseCase.Affiliation;

public static class AffiliationEndpointRegistration
{
    public static IEndpointRouteBuilder MapEndpointsForAffiliateCommercialEstablishmentUseCases(
        this IEndpointRouteBuilder endpointBuilder)
    {
        var group = endpointBuilder.MapGroup("/affiliations");

        group
            .MapPost("/",
                (HttpRequest httpRequest, CancellationToken cancellationToken) => httpRequest
                    .ExecuteUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
                        AffiliateCommercialEstablishmentUseCaseResponse>(
                        endpointBuilder,
                        Results.Ok
                    )
            )
            .Accepts<AffiliateCommercialEstablishmentUseCaseRequest>("application/json")
            .Produces<AffiliateCommercialEstablishmentUseCaseResponse>(StatusCodes.Status200OK, "application/json")
            .WithOpenApi();

        return endpointBuilder;
    }
}