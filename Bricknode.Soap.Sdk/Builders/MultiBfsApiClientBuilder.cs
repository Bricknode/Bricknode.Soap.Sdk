namespace Bricknode.Soap.Sdk.Builders
{
    using System;
    using System.Collections.Generic;
    using Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class MultiBfsApiClientBuilder : IMultiBfsApiClientBuilder
    {
        public IServiceCollection Services { get; }

        private readonly Dictionary<string, BfsApiConfiguration> _apiConfigurations = new Dictionary<string, BfsApiConfiguration>();

        public MultiBfsApiClientBuilder(IServiceCollection services)
            => Services = services;

        public void AddBfsApiConfiguration(string bfsApiClientName, BfsApiConfiguration bfsApiConfiguration)
        {
            if (_apiConfigurations.ContainsKey(bfsApiClientName))
                throw new Exception($"A BfsApiClient with name {bfsApiClientName} has already been added.");

            _apiConfigurations.Add(bfsApiClientName, bfsApiConfiguration);
        }

        public Dictionary<string, BfsApiConfiguration> GetBfsApiConfigurations()
            => _apiConfigurations;
    }
}