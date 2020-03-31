namespace Bricknode.Soap.Sdk.Builders
{
    using System.Collections.Generic;
    using Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IMultiBfsApiClientBuilder
    {
        IServiceCollection Services { get; }

        void AddBfsApiConfiguration(string key, BfsApiConfiguration bfsApiConfiguration);
        Dictionary<string, BfsApiConfiguration> GetBfsApiConfigurations();
    }
}