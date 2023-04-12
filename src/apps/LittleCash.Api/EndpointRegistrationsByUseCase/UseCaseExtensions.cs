using LittleCash.Core.Shared.UseCases;

namespace LittleCash.Api.EndpointRegistrationsByUseCase;

public static class UseCaseExtensions
{
    public static async Task<IResult> ExecuteUseCase<TRequest, TResponse>(
        this HttpRequest httpRequest, IEndpointRouteBuilder endpointBuilder, Func<object, IResult> action)
        where TRequest : class, IUseCaseRequest
        where TResponse : class, IUseCaseResponse
    {
        var request =
            await httpRequest.ReadFromJsonAsync<TRequest>();

        if (request is null)
            throw new Exception("Could not load request");

        var requestScope = endpointBuilder
            .ServiceProvider
            .CreateScope()
            .ServiceProvider;

        var response = await requestScope
            .GetRequiredService<IUseCase<TRequest,
                TResponse>>()
            .ExecuteAsync(request);

        return action.Invoke(response);
    }
}