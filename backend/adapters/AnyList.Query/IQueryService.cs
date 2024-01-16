namespace Microsoft.Extensions.DependencyInjection;

public interface IQueryService
{
    void ConnectAsync(CancellationToken cancellationToken = default);
}