using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Microsoft.Extensions.DependencyInjection;

internal class QueryService : IQueryService
{
    private readonly IConfiguration _configuration;

    public QueryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConnectAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            // possibly empty string I guess
            var connectionString = _configuration.GetConnectionString("psql");
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine(connection.State);// will be set to OPEN
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}