namespace LittleCash.Api.UseCases;

public interface IUseCase<TRequest, TResponse>
    where TRequest : class, IUseCaseRequest
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> ExecuteAsync(TRequest request);
}