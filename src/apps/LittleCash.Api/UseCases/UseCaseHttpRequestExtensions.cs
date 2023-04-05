using Microsoft.AspNetCore.Mvc;

namespace LittleCash.Api.UseCases;

public static class UseCaseHttpRequestExtensions
{
    public static async Task<ActionResult> ExecuteUseCase<TRequest, TResponse>(
        this HttpRequest httpRequest, IEndpointRouteBuilder endpointBuilder, Func<object, ActionResult> action)
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