namespace Bricknode.Soap.Sdk.Builders
{
    using System;
    using System.Collections.Generic;
    using Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class MultiBfsApiClientBuilder : IMultiBfsApiClientBuilder
    {
        public IServiceCollection Services { get; }

        private static readonly Dictionary<string, BfsApiConfiguration> ApiConfigurations = new Dictionary<string, BfsApiConfiguration>();

        public MultiBfsApiClientBuilder(IServiceCollection services)
            => Services = services;

        public void AddBfsApiConfiguration(string bfsApiClientName, BfsApiConfiguration bfsApiConfiguration)
        {
            if (ApiConfigurations.ContainsKey(bfsApiClientName))
                throw new Exception($"A BfsApiClient with name {bfsApiClientName} has already been added.");

            ApiConfigurations.Add(bfsApiClientName, bfsApiConfiguration);
        }

        public Dictionary<string, BfsApiConfiguration> GetBfsApiConfigurations()
            => ApiConfigurations;
    }
}