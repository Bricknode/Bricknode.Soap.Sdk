namespace Bricknode.Soap.Sdk.Factories
{
    using BfsApi;
    using Configuration;

    public interface IBfsApiClientFactory
    {
        (bfsapiSoap Client, BfsApiConfiguration BfsApiConfiguration) CreateClient(string bfsApiClientName);
    }
}