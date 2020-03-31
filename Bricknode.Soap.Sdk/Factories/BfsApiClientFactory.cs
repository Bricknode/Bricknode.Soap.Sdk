namespace Bricknode.Soap.Sdk.Factories
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using BfsApi;
    using Configuration;
    using Helpers;

    public class BfsApiClientFactory : IBfsApiClientFactory
    {
        private static Dictionary<string, BfsApiConfiguration> _bfsApiConfigurations;

        public void AddConfigurations(Dictionary<string, BfsApiConfiguration> configurations)
        {
            _bfsApiConfigurations = configurations;
        } 

        public (bfsapiSoap Client, BfsApiConfiguration BfsApiConfiguration) CreateClient(string bfsApiClientName)
        {
            if (!_bfsApiConfigurations.ContainsKey(bfsApiClientName))
                throw new KeyNotFoundException($"Missing BfsApiClient for name {bfsApiClientName}");

            var bfsApiConfiguration = _bfsApiConfigurations[bfsApiClientName];

            return 
                (CreateSoapClient(bfsApiConfiguration), bfsApiConfiguration);
        }

        private static bfsapiSoapClient CreateSoapClient(BfsApiConfiguration bfsApiConfiguration)
            => new bfsapiSoapClient(BfsBinding.GetBfsBinding(), new EndpointAddress(bfsApiConfiguration.EndpointAddress));
    }
}