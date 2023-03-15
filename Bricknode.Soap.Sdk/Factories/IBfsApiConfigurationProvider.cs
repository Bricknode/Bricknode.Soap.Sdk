using Bricknode.Soap.Sdk.Configuration;
using System.Threading.Tasks;

namespace Bricknode.Soap.Sdk.Factories;

public interface IBfsApiConfigurationProvider
{
    ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null);
}