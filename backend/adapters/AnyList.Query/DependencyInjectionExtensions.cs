namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        return services.AddSingleton<IQueryService, QueryService>();
    }
}