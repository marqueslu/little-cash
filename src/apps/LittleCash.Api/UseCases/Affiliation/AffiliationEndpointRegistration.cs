using System.Net;
using LittleCash.Api.UseCases.Affiliation.AffiliateCommercialEstablishmentUseCase;
using Microsoft.AspNetCore.Mvc;

namespace LittleCash.Api.UseCases.Affiliation;

public static class AffiliationEndpointRegistration
{
    public static IEndpointRouteBuilder MapAffiliateCommercialEstablishmentUseCases(
        this IEndpointRouteBuilder endpointBuilder)
    {
        var group = endpointBuilder
            .MapGroup("/affiliations");

        group
            .MapPost("/",
                (HttpRequest httpRequest) =>
                    httpRequest
                        .ExecuteUseCase<AffiliateCommercialEstablishmentUseCaseRequest,
                            AffiliateCommercialEstablishmentUseCaseResponse>(
                            endpointBuilder,
                            (response) => new ObjectResult(response)
                            {
                                StatusCode = StatusCodes.Status200OK
                            })
            )
            .Accepts<AffiliateCommercialEstablishmentUseCaseRequest>("application/json")
            .Produces<AffiliateCommercialEstablishmentUseCaseResponse>(StatusCodes.Status200OK, "application/json")
            .WithOpenApi();

        return endpointBuilder;
    }
}